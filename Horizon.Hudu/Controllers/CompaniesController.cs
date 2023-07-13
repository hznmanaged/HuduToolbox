using Horizon.Hudu.Models;
using Horizon.Hudu.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Horizon.Hudu.Controllers
{
    public class CompaniesController
    {
        private const string PATH = "api/v1/companies";

        private readonly HuduAPIClient Client;
        public CompaniesController(HuduAPIClient client)
        {
            this.Client = client;
        }

        public async IAsyncEnumerable<Company> GetAll(string? name = null)
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

                var uriBuilder = new UriBuilder(targetUrl);

                var page = 1;

                while (true)
                {
                    queryArgs["page"] = page;
                    uriBuilder.Query = queryArgs.ToQueryString();
                    var response = await restclient.GetAsync(uriBuilder.ToString());
                    var content = await response.Content.ReadAsStringAsync();
                    await response.ThrowIfNotSuccess();;

                    var result = JsonSerializer.Deserialize<CompaniesGetResponse>(content);
                    if(result==null||!(result.Companies?.Any()??false))
                    {
                        yield break;
                    }
                    foreach(var item in result.Companies)
                    {
                        yield return item;
                    }
                    page++;
                }
            }
        }

        //public async Task Update(Article article)
        //{
        //    if (String.IsNullOrWhiteSpace(article.Name))
        //    {
        //        throw new Exception("Article name is required");
        //    }

        //    if (String.IsNullOrWhiteSpace(article.Content))
        //    {
        //        throw new Exception("Article content is required");
        //    }
        //    var request = new Dictionary<string, object>();
        //    request["name"] = article.Name;
        //    request["content"] = article.Content;

        //    using (var restclient = Client.InstantiateRestClient())
        //    {
        //        string targetUrl = StringTools.CombineURI(Client.URL, PATH, article.ID.ToString());

        //        var requestJson = JsonSerializer.Serialize(request);

        //        var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");


        //        var response = await restclient.PutAsync(targetUrl, requestContent);
        //        await response.ThrowIfNotSuccess();;
        //    }
        //}
    }
}
