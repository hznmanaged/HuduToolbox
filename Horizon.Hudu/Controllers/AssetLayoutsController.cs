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
    public class AssetLayoutsController
    {
        private const string PATH = "api/v1/asset_layouts";

        private readonly HuduAPIClient Client;
        public AssetLayoutsController(HuduAPIClient client)
        {
            this.Client = client;
        }

        public async IAsyncEnumerable<AssetLayout> GetAll(string name = null)
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
                    await response.ThrowIfNotSuccess();;
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<AssetLayoutsGetResponse>(content);
                    if (result == null || !(result.AssetLayouts?.Any() ?? false))
                    {
                        yield break;
                    }
                    foreach (var item in result.AssetLayouts)
                    {
                        yield return item;
                    }
                    page++;
                }
            }
        }

        public async Task<AssetLayout> GetByID(int id)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, PATH, id.ToString());

                var response = await restclient.GetAsync(targetUrl);
                await response.ThrowIfNotSuccess();;
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<AssetLayoutGetResponse>(content);
                return result.AssetLayout;
            }
        }
     
    }
}
