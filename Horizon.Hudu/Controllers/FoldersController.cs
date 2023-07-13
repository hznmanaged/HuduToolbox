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
    public class FoldersController
    {
        private const string PATH = "api/v1/folders";

        private readonly HuduAPIClient Client;
        public FoldersController(HuduAPIClient client)
        {
            this.Client = client;
        }

        public async IAsyncEnumerable<Folder> GetAll(
            string? name = null,
            int? companyId = null)
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
                if(companyId.HasValue)
                {
                    queryArgs["company_id"] = companyId;
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

                    var result = JsonSerializer.Deserialize<FoldersGetResponse>(content);
                    if(result==null||!(result.Folders?.Any()??false))
                    {
                        yield break;
                    }
                    foreach(var item in result.Folders)
                    {
                        yield return item;
                    }
                    page++;
                }
            }
        }

        private string CreateFolderRequest(Folder item)
        {
            if (String.IsNullOrWhiteSpace(item.Name))
            {
                throw new Exception("Name is required");
            }

            var request = new Dictionary<string, object>();
            request["name"] = item.Name;

            if (!String.IsNullOrWhiteSpace(item.Description))
            {
                request["description"] = item.Description;
            }
            if (!String.IsNullOrWhiteSpace(item.Icon))
            {
                request["icon"] = item.Icon;
            }
            if (item.ParentFolderID.HasValue)
            {
                request["parent_folder_id"] = item.ParentFolderID.Value;
            }
            if (item.CompanyID.HasValue)
            {
                request["company_id"] = item.CompanyID.Value;
            }

            return JsonSerializer.Serialize(
                    new { folder = request });
        }


        public async Task<Folder> Create(Folder item)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, PATH);

                var requestJson = CreateFolderRequest(item);

                var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                try
                {
                    var response = await restclient.PostAsync(targetUrl, requestContent);
                    await response.ThrowIfNotSuccess();;
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<FolderResponse>(content);
                    return result.Folder;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<Folder> Update(Folder item)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, PATH, item.ID.ToString());

                var requestJson = CreateFolderRequest(item).Replace("\u0027", "'");

                var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                try
                {
                    var response = await restclient.PutAsync(targetUrl, requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    await response.ThrowIfNotSuccess();;


                    var result = JsonSerializer.Deserialize<FolderResponse>(responseContent);
                    return result.Folder;

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
