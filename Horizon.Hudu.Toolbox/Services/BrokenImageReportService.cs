using Horizon.Hudu.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static System.Net.WebRequestMethods;


namespace Horizon.Hudu.Toolbox.Services
{
    public class BrokenImageReportService
    {
        private readonly HuduAPIClient huduAPIClient;
        private readonly ILogger<ImageImportService> logger;
        private readonly ServiceHelpers serviceHelpers;
        public BrokenImageReportService(HuduAPIClient huduAPIClient, ILogger<ImageImportService> logger, ServiceHelpers serviceHelpers)
        {
            this.huduAPIClient = huduAPIClient;
            this.logger = logger;
            this.serviceHelpers = serviceHelpers;
        }

        public async Task<string> Run(SharedServiceSettings settings, CancellationToken cancellationToken)
        {
            logger.LogInformation("Beginning generating broken image report");

            var output = new StringBuilder($"<html><head><title>Broken images report</title></head><body><h1>Broken images report, generated {DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}</h1><table><tr><th>URL</th><th>Images</th></tr>");

            var resultCount = 0;

            if (settings.IncludeArticles)
            {
                await serviceHelpers.IterateAndUpdateArticles(huduAPIClient, async (article) =>
                {

                    var doc = article.HTML;
                    var result = await CheckImageSources(doc, huduUrl: this.huduAPIClient.URL);

                    if (result.Any())
                    {
                        output.AppendLine($"<tr><td><a href=\"{HttpUtility.HtmlAttributeEncode(article.URL)}\">{HttpUtility.HtmlEncode(article.URL)}</td><td><ul>");
                        foreach (var image in result)
                        {
                            output.AppendLine($"<li><a href=\"{HttpUtility.HtmlAttributeEncode(image)}\">{HttpUtility.HtmlEncode(image)}</li>");
                        }
                        output.AppendLine($"</ul></td></tr>");
                        resultCount += result.Count();
                    }

                    return false;
                }, searchFilter: settings.SearchString, dryRun: true, cancellationToken: cancellationToken);
            }

            if (cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Cancellation requested, stopping broken image report");
                return "";
            }


            if (settings.IncludeAssets)
            {
                await serviceHelpers.IterateAndUpdateAssetFields(huduAPIClient, async (fieldIteration) =>
                {
                    var doc = fieldIteration.HTML;
                    var result = await CheckImageSources(doc, huduUrl: this.huduAPIClient.URL);

                    if (result.Any())
                    {
                        output.AppendLine($"<tr><td><a href=\"{HttpUtility.HtmlAttributeEncode(fieldIteration.Asset.URL)}\">{HttpUtility.HtmlEncode(fieldIteration.Asset.URL)}</td><td><ul>");
                        foreach (var image in result)
                        {
                            output.AppendLine($"<li><a href=\"{HttpUtility.HtmlAttributeEncode(image)}\">{HttpUtility.HtmlEncode(image)}</li>");
                        }
                        resultCount += result.Count();
                        output.AppendLine($"</ul></td></tr>");
                    }



                    return false;
                }, searchFilter: settings.SearchString, dryRun: true, cancellationToken: cancellationToken);
            }

            output.AppendLine("</table></body></html>");


            if (cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Cancellation requested, stopping broken image report");
                return "";
            }



            if (resultCount == 0)
            {
                logger.LogInformation("No broken images detected");
                return "";
            }


            return output.ToString();
        }



        private async Task<List<string>> CheckImageSources(HtmlAgilityPack.HtmlDocument doc, string huduUrl)
        {
            var output = new List<string>();

            var imageNodes = doc.DocumentNode.Descendants("img");
            foreach (var imageNode in imageNodes)
            {
                var imageUrl = imageNode.GetAttributeValue("src", null);

                if(imageUrl.ToLower().StartsWith("data:"))
                {
                    logger.LogInformation($"Found image an embedded data image, skipping");
                    continue;
                }
                else
                {
                    logger.LogInformation($"Found image {imageUrl}");

                }

                if (!imageUrl.ToLower().StartsWith("http"))
                {
                    huduAPIClient.GetAbsoluteURL(imageUrl);
                }

                if (!imageUrl.ToLower().StartsWith("http"))
                {
                    continue;
                }



                Match match = null;
                foreach (var rx in SharedData.GetInternalImageRegexes(serverUrl: huduUrl))
                {
                    match = rx.Match(imageUrl);
                    if (match.Success)
                    {
                        break;
                    }
                }

                if (match != null && match.Success)
                {
                    continue;
                }

                byte[] data;
                using (var webClient = new WebClient())
                {
                    //webClient.UseDefaultCredentials = true;
                    try
                    {
                        data = webClient.DownloadData(imageUrl);
                    }
                    catch (Exception ex)
                    {
                        output.Add(imageUrl);
                    }
                }
            }
            return output;
        }
    }
}
