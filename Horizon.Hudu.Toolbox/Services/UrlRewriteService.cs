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
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Horizon.Hudu.Toolbox.Services
{
    public class UrlRewriteService
    {

        private class LinkRewrite
        {
            public Regex Regex { get; set; }

            /// <summary>
            /// The function that will be called to generate the re-written string.
            /// Parameter 1 is the match result of the regex specified on this LinkReWrite.
            /// Parameter 2 is a bool indicating if the rewrite should be formatted for user display (true), of for use as an aattribute like src or href (false).
            /// </summary>
            public Func<System.Text.RegularExpressions.Match, bool, string> Action;
            public bool IsApplicable(string input) => this.Regex.IsMatch(input);
            public string PerformRewrite(string input)
            {
                var match = Regex.Match(input);
                if (match.Success)
                {
                    return this.Action(match, false);
                }
                return input;
            }
            public string PerformDisplayRewrite(string input)
            {
                var match = Regex.Match(input);
                if (match.Success)
                {
                    return this.Action(match, true);
                }
                return input;
            }
        }



        private readonly HuduAPIClient huduAPIClient;
        private readonly ILogger<UrlRewriteService> logger;
        private readonly ServiceHelpers serviceHelpers;
        public UrlRewriteService(HuduAPIClient huduAPIClient, ILogger<UrlRewriteService> logger, 
            ServiceHelpers serviceHelpers)
        {
            this.huduAPIClient = huduAPIClient;
            this.logger = logger;
            this.serviceHelpers = serviceHelpers;
        }

        public async Task Run(SharedServiceSettings settings, IList<RewriteUrlSettingsEntry> rewrites, 
            CancellationToken cancellationToken)
        {
            logger.LogInformation("Beginning image imports");

            if (settings.IncludeArticles)
            {
                await serviceHelpers.IterateAndUpdateArticles(huduAPIClient, async (article) =>
                {

                    var doc = article.HTML;
                    var result = await UpdateURLs(doc, rewrites);

                    if (result)
                    {
                        article.Article.Content = doc.DocumentNode.OuterHtml;
                    }

                    return result;
                }, searchFilter: settings.SearchString, dryRun: settings.DryRun, cancellationToken: cancellationToken);
            }

            if (cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Cancellation requested, stopping URL rewrite process");
                return;
            }



            if (settings.IncludeAssets)
            {
                await serviceHelpers.IterateAndUpdateAssetFields(huduAPIClient, async (fieldIteration) =>
                {
                    var doc = fieldIteration.HTML;
                    var result = await UpdateURLs(doc, rewrites);

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
                logger.LogInformation("Cancellation requested, stopping URL rewrite process");
                return;
            }


            logger.LogInformation("URL rewrite process completed");
        }


        private async Task<bool> UpdateURLs(HtmlAgilityPack.HtmlDocument doc, IList<RewriteUrlSettingsEntry> rewrites)
        {
            var result = false;

            var linkNodes = doc.DocumentNode.Descendants("a");

            foreach (var linkNode in linkNodes)
            {
                var linkUrl = linkNode.GetAttributeValue("href", null);
                var linkText = linkNode.InnerHtml;

                foreach (var rewrite in rewrites)
                {
                    var candidate = rewrite.GenerateReplacementOutput(linkUrl);
                    var linkResult = false;
                    if (candidate != linkUrl)
                    {
                        linkNode.SetAttributeValue("href", candidate);
                        linkResult = true;
                    }

                    candidate = rewrite.GenerateReplacementDisplayOutput(linkText);
                    if (candidate != linkText)
                    {
                        linkNode.InnerHtml = candidate;
                        linkResult = true;
                    }
                    if(linkResult)
                    {
                        result = true;
                        break;
                    }
                }
            }

            var imageNodes = doc.DocumentNode.Descendants("img");
            foreach (var imageNode in imageNodes)
            {
                var imageUrl = imageNode.GetAttributeValue("src", null);

                foreach (var rewrite in rewrites)
                {
                    var candidate = rewrite.GenerateReplacementOutput(imageUrl);
                    if (candidate != imageUrl)
                    {
                        imageNode.SetAttributeValue("src", candidate);
                        result = true;
                        break;
                    }

                }

            }

            return result;
        }
    }
}
