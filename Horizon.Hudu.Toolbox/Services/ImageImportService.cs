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
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace Horizon.Hudu.Toolbox.Services
{
    public class ImageImportService
    {
        internal static readonly string[] DOWNLOADABLE_MIMES = new string[]
        {
            "image/webp",
            "image/png",
            "image/jpeg"
        };

        private readonly HuduAPIClient huduAPIClient;
        private readonly ILogger<ImageImportService> logger;
        private readonly ServiceHelpers serviceHelpers;

        public ImageImportService(HuduAPIClient huduAPIClient, ILogger<ImageImportService> logger, ServiceHelpers serviceHelpers)
        {
            this.huduAPIClient = huduAPIClient;
            this.logger = logger;
            this.serviceHelpers = serviceHelpers;
        }

        public async Task Run(SharedServiceSettings settings, CancellationToken cancellationToken)
        {
            logger.LogInformation("Beginning image imports");

            if (settings.IncludeArticles)
            {
                await serviceHelpers.IterateAndUpdateArticles(huduAPIClient, async (article) =>
                {

                    var doc = article.HTML;
                    var result = await UpdateImageLinks(doc,
                        backupAction: async (fileName, data) =>
                        {
                            await serviceHelpers.BackupArticleImage(articleId: article.Article.ID, imageName: fileName, data);
                        },
                        huduServer: this.huduAPIClient.URL,
                        cancellationToken: cancellationToken);

                    if (result)
                    {
                        article.Article.Content = doc.DocumentNode.OuterHtml;
                    }


                    return result;
                }, searchFilter: settings.SearchString, dryRun: settings.DryRun, cancellationToken: cancellationToken);
            }

            if (cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Cancellation requested, stopping image import process");
                return;
            }

            if (settings.IncludeAssets)
            {
                await serviceHelpers.IterateAndUpdateAssetFields(huduAPIClient, async (fieldIteration) =>
                {
                    var doc = fieldIteration.HTML;
                    var result = await UpdateImageLinks(doc,
                        backupAction: async (fileName, data) =>
                        {
                            await serviceHelpers.BackupAssetImage(assetId: fieldIteration.Asset.ID, imageName: fileName, data);
                        },
                        huduServer: this.huduAPIClient.URL,
                        cancellationToken: cancellationToken);

                    if (result)
                    {
                        logger.LogInformation("Article was updated, saving");
                        fieldIteration.Field.Value = doc.DocumentNode.OuterHtml;
                    }

                    return result;
                }, searchFilter: settings.SearchString, dryRun: settings.DryRun, cancellationToken: cancellationToken);
            }


            if (cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Cancellation requested, stopping image import process");
                return;
            }


            logger.LogInformation("Image import process completed");

        }



        private async Task<bool> UpdateImageLinks(HtmlAgilityPack.HtmlDocument doc,
            Func<string, byte[], Task> backupAction, 
            string huduServer,
            CancellationToken cancellationToken)
        {
            var imageNodes = doc.DocumentNode.Descendants("img");
            var result = false;
            foreach (var imageNode in imageNodes)
            {
                if(cancellationToken.IsCancellationRequested)
                {
                    break;
                }

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
                    continue;
                }

                Match match = null;
                foreach (var rx in SharedData.GetInternalImageRegexes(serverUrl: huduServer))
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
                        logger.LogWarning(ex, $"Error while attempting to download {imageUrl}");
                        continue;
                    }
                }

                string? mime = serviceHelpers.GetMimeType(data);

                if(!DOWNLOADABLE_MIMES.Contains(mime))
                {
                    // This means it's not an understood image type
                    logger.LogWarning($"Unable to identify mime type of {imageUrl} ({mime}), skipping");
                    continue;
                }

                var base64 = Convert.ToBase64String(data);
                var newstring = $"data:{mime};base64, {base64}";
                imageNode.SetAttributeValue("src", newstring);

                await backupAction(imageUrl, data);

                result = true;
            }
            return result;
        }
    }
}
