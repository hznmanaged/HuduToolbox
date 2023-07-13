using Horizon.Hudu.Models;
using Horizon.Hudu.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Horizon.Hudu.Controllers
{
    public class ArticlesController
    {
        private const string PATH = "api/v1/articles";

        private readonly HuduAPIClient Client;
        public ArticlesController(HuduAPIClient client)
        {
            this.Client = client;
        }

        public async IAsyncEnumerable<Article> GetAll(string? name = null, int? companyId = null, bool? archived = null)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, PATH);

                var queryArgs = new Dictionary<string, object>()
                {
                    
                };

                if (!String.IsNullOrWhiteSpace(name))
                {
                    queryArgs["name"] = name;
                }
                if (companyId.HasValue)
                {
                    queryArgs["company_id"] = companyId.Value;
                }
                if (archived.HasValue)
                {
                    queryArgs["archived"] = archived.Value ? 1 : 0;
                }
                var uriBuilder = new UriBuilder(targetUrl);

                var page = 1;

                while (true)
                {
                    queryArgs["page"] = page;
                    uriBuilder.Query = queryArgs.ToQueryString();
                    var response = await restclient.GetAsync(uriBuilder.ToString());
                    await response.ThrowIfNotSuccess();;
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<ArticlesGetResponse>(content);
                    if(result==null||!(result.Articles?.Any()??false))
                    {
                        yield break;
                    }
                    foreach(var item in result.Articles)
                    {
                        yield return item;
                    }
                    page++;
                }
            }
        }

        private string CreateArticleRequest(Article item)
        {
            if (String.IsNullOrWhiteSpace(item.Name))
            {
                throw new Exception("Name is required");
            }
            if (String.IsNullOrWhiteSpace(item.Content))
            {
                throw new Exception("Article content is required");
            }

            var request = new Dictionary<string, object>();
            request["name"] = item.Name;
            request["content"] = item.Content;
            if (item.FolderID.HasValue)
            {
                request["folder_id"] = item.FolderID.Value;
            }
            if (item.CompanyID.HasValue)
            {
                request["company_id"] = item.CompanyID.Value;
            }

            return JsonSerializer.Serialize(
                    new { article = request });
        }


        public async Task Update(Article item)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, PATH, item.ID.ToString());

                var requestJson = CreateArticleRequest(item).Replace("\u0027", "'");

                var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");


                var response = await restclient.PutAsync(targetUrl, requestContent);
                await response.ThrowIfNotSuccess();;
            }
        }

        public async Task<Article> Create(Article item)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, PATH);

                var requestJson = CreateArticleRequest(item);

                var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
                string content = "";
                try
                {
                    var response = await restclient.PostAsync(targetUrl, requestContent);
                    content = await response.Content.ReadAsStringAsync();
                    await response.ThrowIfNotSuccess();

                    var result = JsonSerializer.Deserialize<ArticleResponse>(content);
                    return result.Article;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }




        public async Task Delete(long id)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, PATH, id.ToString());


                var response = await restclient.DeleteAsync(targetUrl);
                await response.ThrowIfNotSuccess();;
            }
        }


    }
}
