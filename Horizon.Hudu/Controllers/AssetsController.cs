using Horizon.Hudu.Models;
using Horizon.Hudu.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Horizon.Hudu.Controllers
{
    public class AssetsController
    {
        private const string PATH = "api/v1/assets";

        private readonly HuduAPIClient Client;
        public AssetsController(HuduAPIClient client)
        {
            this.Client = client;
        }

        public async IAsyncEnumerable<Asset> GetAll(
            string? name = null,
            string? primarySerial = null,
            int? assetLayoutId = null,
            int? companyId = null)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, PATH);

                var queryArgs = new Dictionary<string, object>()
                {

                };

                if (!String.IsNullOrWhiteSpace(primarySerial))
                {
                    queryArgs["primary_serial"] = primarySerial;
                }
                if (!String.IsNullOrWhiteSpace(name))
                {
                    queryArgs["name"] = name;
                }
                if (companyId.HasValue)
                {
                    queryArgs["company_id"] = companyId.Value;
                }
                if (assetLayoutId.HasValue)
                {
                    queryArgs["asset_layout_id"] = assetLayoutId.Value;
                }

                var uriBuilder = new UriBuilder(targetUrl);

                var page = 1;

                while (true)
                {
                    queryArgs["page"] = page;
                    uriBuilder.Query = queryArgs.ToQueryString();
                    var response = await restclient.GetAsync(uriBuilder.ToString());
                    try
                    {
                        await response.ThrowIfNotSuccess();;
                    }
                    catch (HttpRequestException)
                    {
                        throw;
                    }
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<AssetsGetResponse>(content);
                    if (result == null || !(result.Assets?.Any() ?? false))
                    {
                        yield break;
                    }
                    foreach (var item in result.Assets)
                    {
                        yield return item;
                    }
                    page++;
                }
            }
        }
        public async IAsyncEnumerable<Asset> GetByCompany(int company)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, "api/v1/companies", company.ToString(), "assets");

                var queryArgs = new Dictionary<string, object>()
                {
                };
                
                var uriBuilder = new UriBuilder(targetUrl);

                var page = 1;

                while (true)
                {
                    queryArgs["page"] = page;
                    uriBuilder.Query = queryArgs.ToQueryString();
                    var response = await restclient.GetAsync(uriBuilder.ToString());
                    var content = await response.Content.ReadAsStringAsync();
                    try
                    {
                        await response.ThrowIfNotSuccess();;
                    }
                    catch (HttpRequestException)
                    {
                        throw;
                    }

                    var result = JsonSerializer.Deserialize<AssetsGetResponse>(content);
                    if (result == null || !(result.Assets?.Any() ?? false))
                    {
                        yield break;
                    }
                    foreach (var item in result.Assets)
                    {
                        yield return item;
                    }
                    page++;
                }
            }
        }

        public async Task<Asset> GetByID(int companyId, int id)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, "api/v1/companies", companyId.ToString(), "assets", id.ToString());
                
                var response = await restclient.GetAsync(targetUrl);
                try
                {
                    await response.ThrowIfNotSuccess();;
                }
                catch (HttpRequestException)
                {
                    throw;
                }
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<AssetResponse>(content);

                return result.Asset;
            }
        }

        private string CreateAssetRequest(Asset item)
        {
            if (String.IsNullOrWhiteSpace(item.Name))
            {
                throw new Exception("Name is required");
            }

            var request = new Dictionary<string, object>();
            request["asset_layout_id"] = item.AssetLayoutID;
            request["name"] = item.Name;

            if (!String.IsNullOrWhiteSpace(item.PrimarySerial))
            {
                request["primary_serial"] = item.PrimarySerial;
            }
            if (!String.IsNullOrWhiteSpace(item.PrimaryMail))
            {
                request["primary_mail"] = item.PrimaryMail;
            }
            if (!String.IsNullOrWhiteSpace(item.PrimaryModel))
            {
                request["primary_model"] = item.PrimaryModel;
            }
            if (!String.IsNullOrWhiteSpace(item.PrimaryManufacturer))
            {
                request["primary_manufacturer"] = item.PrimaryManufacturer;
            }
            if (item.Fields.Any())
            {
                var fields = new Dictionary<string, object>();
                foreach (var field in item.Fields)
                {
                    var value = field.Value;
                    var valueString = field.Value?.ToString();
                    object valueToUse;
                    if (value is Asset assetValue)
                    {
                        valueToUse = JsonSerializer.Serialize(new List<object>() { assetValue.ToReferenceMap() });
                                        //.Replace("'","\\'").Replace('"','\'');
                    }
                    else if (value is IEnumerable<Asset> assetValues)
                    {
                        valueToUse = JsonSerializer.Serialize(assetValues.Select(e => e.ToReferenceMap()));
                                        //.Replace("'", "\\'").Replace('"', '\'');
                    }
                    else
                    {
                        valueToUse = valueString;
                    }
                    if (valueToUse != null)
                    {
                        fields[field.Label.ToLower().Replace(' ', '_')] = valueToUse;
                    }
                }
                request["custom_fields"] = new List<object>() { fields };
            }

            return JsonSerializer.Serialize(
                    new { asset = request });
        }

        public async Task<Asset> Create(Asset item)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, "api/v1/companies", item.CompanyID.ToString(), "assets");

                var requestJson = CreateAssetRequest(item);

                var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                try
                {
                    var response = await restclient.PostAsync(targetUrl, requestContent);
                    await response.ThrowIfNotSuccess();;
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<AssetResponse>(content);
                    return result.Asset;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task Update(Asset item)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, "api/v1/companies", item.CompanyID.ToString(), "assets", item.ID.ToString());

                var requestJson = CreateAssetRequest(item).Replace("\u0027","'");

                var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                try
                {
                    var response = await restclient.PutAsync(targetUrl, requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    await response.ThrowIfNotSuccess();;
                } catch(Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task DeleteByID(int companyId, int id)
        {
            using (var restclient = Client.InstantiateRestClient())
            {
                string targetUrl = StringTools.CombineURI(Client.URL, "api/v1/companies", companyId.ToString(), "assets", id.ToString());

                var response = await restclient.DeleteAsync(targetUrl);
                try
                {
                    await response.ThrowIfNotSuccess();;
                }
                catch (HttpRequestException ex)
                {
                    throw;
                }
            }
        }
    }
}
