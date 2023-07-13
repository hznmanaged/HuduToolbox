using Horizon.Hudu.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using MimeDetective;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Horizon.Hudu.Toolbox.Services
{
    public class ServiceHelpers
    {
        private const string BACKUP_FOLDER = @"D:\backups\hudu";
        private readonly ILogger<ServiceHelpers> logger;
        private readonly ContentInspector contentInspector;

        public class ArticleIteration
        {
            internal Article Article { get; set; }
            internal string URL { get; set; }
            internal HtmlAgilityPack.HtmlDocument HTML { get; set; }
        }
        public class AssetIteration
        {
            internal Asset Asset { get; set; }
            internal string URL { get; set; }
        }
        public class AssetFieldIteration: AssetIteration
        {
            internal FieldValue Field { get; set; }
            internal HtmlAgilityPack.HtmlDocument HTML { get; set; }

            public AssetFieldIteration(AssetIteration assetIteration)
            {
                this.URL = assetIteration.URL;
                this.Asset = assetIteration.Asset;
            }

        }

        public ServiceHelpers(ILogger<ServiceHelpers> logger, ContentInspector contentInspector)
        {
            this.logger = logger;
            this.contentInspector = contentInspector;
        }

        public async Task IterateAndUpdateArticles(HuduAPIClient client, Func<ArticleIteration, Task<bool>> iterationProcess, 
            bool dryRun, string searchFilter, CancellationToken cancellationToken)
        {

            var articles = client.Articles.GetAll(name: searchFilter);
            await foreach (var article in articles)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    logger.LogInformation("Cancellation requested, breaking from article loop");
                    break;
                }


                logger.LogInformation($"Processing article {article.ID} at {article.URL}");
                if (String.IsNullOrWhiteSpace(article.Content))
                {
                    logger.LogInformation("Article empty, skipping");
                    continue;
                }

                
                var originalContent = article.Content;
                var iteration = new ArticleIteration()
                {
                    Article = article,
                    URL = client.GetObjectAbsoluteURL(article),
                };

                iteration.HTML = ParseHtmlDocument(article.Content);

                var updated = await iterationProcess(iteration);
                if(updated)
                {
                    logger.LogInformation("Article was updated, saving");
                    await BackupArticle(article.ID, originalContent);
                    if (!dryRun)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            logger.LogInformation("Cancellation requested, breaking from article loop");
                            break;
                        }
                        await client.Articles.Update(iteration.Article);
                    }
                }
            }
        }

        public async Task IterateAndUpdateAssets(HuduAPIClient client, Func<AssetIteration, Task<bool>> iterationProcess, 
            string searchFilter, bool dryRun, CancellationToken cancellationToken)
        {

            var assets = client.Assets.GetAll(name: searchFilter);
            await foreach (var asset in assets)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    logger.LogInformation("Cancellation requested, breaking from asset loop");
                    break;
                }


                logger.LogInformation($"Processing asset {asset.ID} at {asset.URL}");
                //var originalContent = assets.Content;
                var contentBackup = GenerateAssetBackup(asset);
                var iteration = new AssetIteration()
                {
                    Asset = asset,
                    URL = client.GetObjectAbsoluteURL(asset),
                };

                var updated = await iterationProcess(iteration);
                if (updated)
                {
                    logger.LogInformation($"Asset {asset.ID} updated, saving");
                    await BackupAsset(asset.ID, contentBackup);
                    if (!dryRun)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            logger.LogInformation("Cancellation requested, breaking from asset loop");
                            break;
                        }

                        await client.Assets.Update(iteration.Asset);
                    }
                }
            }
        }

        public async Task IterateAndUpdateAssetFields(HuduAPIClient client, Func<AssetFieldIteration, Task<bool>> iterationProcess, 
            string searchFilter, bool dryRun, CancellationToken cancellationToken)
        {
            await IterateAndUpdateAssets(client, iterationProcess: async (asset) =>
            {

                var result = false;
                foreach(var field in asset.Asset.Fields)
                {
                    if(cancellationToken.IsCancellationRequested)
                    {
                        logger.LogInformation("Cancellation requested, breaking from field loop");
                        break;
                    }
                    logger.LogInformation($"Processing field \"{field.Label}\"");

                    var iteration = new AssetFieldIteration(asset)
                    {
                        Field = field,
                    };

                    try
                    {
                        iteration.HTML = ParseHtmlDocument(field.Value?.ToString());
                    } catch(Exception e)
                    {
                        Console.Out.WriteLine();
                    }

                    var updated = await iterationProcess(iteration);
                    if (updated)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            logger.LogInformation("Cancellation requested, breaking from field loop");
                            break;
                        }

                        logger.LogInformation($"Field \"{field.Label}\" updated");
                        result = true;
                    }
                }
                return result;
            }, searchFilter: searchFilter, dryRun: dryRun, cancellationToken: cancellationToken);
        }

        public HtmlAgilityPack.HtmlDocument ParseHtmlDocument(string contents)
        {
            if(contents==null)
            {
                contents = String.Empty;
            }
            var doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc.LoadHtml(contents);
            }
            catch (Exception ex)
            {
                throw;
            }
            return doc;
        }
        private const string OCTET_MIME = "application/octet-stream";
        public string? GetMimeType(byte[] data)
        {
            try
            {
                var mimes = contentInspector.Inspect(data).ByMimeType();
                if(!mimes.Any(e=>e.MimeType!= OCTET_MIME))
                {
                    throw new Exception("No mime types returend from inspector");
                }
                return mimes.First(e => e.MimeType != OCTET_MIME).MimeType;
            }
            catch(Exception ex)
            {
                logger.LogWarning(ex, "Unable to detect mime type");
                return null;
            }
        }

        //public string GetMimeType(Image i)
        //{
        //    var imgguid = i.RawFormat.Guid;
        //    foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageDecoders())
        //    {
        //        if (codec.FormatID == imgguid)
        //            return codec.MimeType;
        //    }
        //    throw new NotSupportedException(i.RawFormat.ToString());
        //}

        public async Task BackupArticleImage(int articleId, string imageName, byte[] data)
        {
            var backupFolder = Path.Combine(BACKUP_FOLDER, "articles", articleId.ToString());
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }
            var imageBackupFileName = Path.Combine(backupFolder,
            StringTools.SanitizeForFileName(imageName));

            await System.IO.File.WriteAllBytesAsync(imageBackupFileName, data);
        }

        public async Task BackupAssetImage(int assetId, string imageName, byte[] data)
        {
            var backupFolder = Path.Combine(BACKUP_FOLDER, "assets", assetId.ToString());
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }
            var imageBackupFileName = Path.Combine(backupFolder,
            StringTools.SanitizeForFileName(imageName));

            await System.IO.File.WriteAllBytesAsync(imageBackupFileName, data);
        }

        public async Task BackupArticle(int articleId, string contents)
        {
            var backupFolder = Path.Combine(BACKUP_FOLDER, "articles", articleId.ToString());
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }

            var filePath = Path.Combine(backupFolder,
                DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".html");

            await System.IO.File.WriteAllTextAsync(filePath, contents);
        }

        public String GenerateAssetBackup(Asset asset)
        {
            var contents = new StringBuilder();

            contents.AppendLine($"<html><head><title>{asset.Name}</title></head><body><h1>{asset.Name}</h1>");

            contents.AppendLine("<h1>Fields</h1><table><tr><th>ID</th><th>Name</th><th>Value</th></tr>");
            foreach (var field in asset.Fields.OrderBy(e => e.Position))
            {
                contents.AppendLine($"<tr><td>{field.ID}</td><td>{field.Label}</td><td>{field.Value}</td></tr>");
            }
            contents.AppendLine("</table>");

            contents.AppendLine($"<h1>Serialized:</h1><pre>{JsonSerializer.Serialize(asset)}</pre>");

            contents.AppendLine("</body></html>");

            return contents.ToString();
        }

        public async Task BackupAsset(int assetId, string contents)
        {
            var backupFolder = Path.Combine(BACKUP_FOLDER, "assets", assetId.ToString());
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }

            var filePath = Path.Combine(backupFolder,
                DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".html");

            await System.IO.File.WriteAllTextAsync(filePath, contents);
        }
    }
}
