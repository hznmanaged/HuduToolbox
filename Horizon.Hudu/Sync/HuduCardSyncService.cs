using Horizon.Hudu.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Horizon.Hudu.Sync
{
    public class HuduCardSyncService: IDisposable
    {
        private readonly ILogger<HuduCardSyncService> Logger;
        private readonly HuduAPIClient Client;
        public HuduCardSyncService(HuduAPIClient client, ILogger<HuduCardSyncService> logger)
        {
            this.Client = client;
            this.Logger = logger;
        }

        public void Dispose()
        {
            Client.Dispose();
        }

        private async Task<object> TranslateFieldValue(AssetLayoutField fieldTemplate,
            JsonElement cardData,
            Asset asset, int fallbackCompany)
        {
            if(cardData.ValueKind == JsonValueKind.Array)
            {
                var elements = new List<object>();
                foreach (JsonElement childElement in cardData.EnumerateArray())
                {
                    elements.Add(await TranslateFieldValue(fieldTemplate, childElement, asset, fallbackCompany));
                }
                switch (fieldTemplate.FieldType)
                {
                    case FieldType.Text:
                        return String.Join(",", elements.Select(e=>e.ToString()));
                    case FieldType.AssetTag:
                        return elements;
                    default:
                        throw new NotSupportedException($"Asset field {fieldTemplate.Label} ({fieldTemplate.ID}) is of unrecognized type {fieldTemplate.FieldType}");
                }
            }

            var stringValue = cardData.GetString();

            switch (fieldTemplate.FieldType)
            {
                case FieldType.Text:
                    return stringValue;
                case FieldType.AssetTag:
                    var assetLayoutId = fieldTemplate.LinkableID;
                    var linkedAssets = await Client.Assets.GetAll(name: stringValue).ToListAsync();
                    var layout2 = await Client.AssetLayouts.GetByID(id: assetLayoutId);
                    var linkedAsset = linkedAssets.FirstOrDefault(e =>
                                e.AssetLayoutID == assetLayoutId &&
                                e.CompanyID == asset.CompanyID);
                    if (linkedAsset == null)
                    {
                        linkedAsset = linkedAssets.FirstOrDefault(e =>
                                e.AssetLayoutID == assetLayoutId &&
                                e.CompanyID == fallbackCompany);
                    }
                    if (linkedAsset == null)
                    {
                        // Asset not found, we create one
                        linkedAsset = new Asset();
                        linkedAsset.AssetLayoutID = assetLayoutId;
                        linkedAsset.CompanyID = asset.CompanyID;
                        linkedAsset.Name = stringValue;
                        linkedAsset = await Client.Assets.Create(linkedAsset);

                        Logger.LogDebug($"Unable to determine linked asset on asset {asset.Name} ({asset.ID}) for field {fieldTemplate.Label} ({fieldTemplate.ID}) with card value {stringValue}, creating new linked asset");
                    }
                    return linkedAsset;
                default:
                    throw new NotSupportedException($"Asset field {fieldTemplate.Label} ({fieldTemplate.ID}) is of unrecognized type {fieldTemplate.FieldType}");
            }

        }

        public async Task SyncCards(IEnumerable<IHuduCardSyncMapping> mappings, int fallbackCompany, string? name = null)
        {
            var assets = Client.Assets.GetAll(name: name);
            await foreach(var asset in assets)
            {
                try
                {
                    var layout = await Client.AssetLayouts.GetByID(id: asset.AssetLayoutID);
                    if (layout == null)
                    {
                        Logger.LogError($"Could not find asset layout {asset.AssetLayoutID} specified on asset {asset.Name} ({asset.ID})");
                        continue;
                    }
                    var updated = false;
                    foreach(var mapping in mappings.Where(e=>e.AssetLayoutID==asset.AssetLayoutID))
                    {
                        var fieldTemplate = layout.Fields.FirstOrDefault(e => e.ID == mapping.AssetFieldID);
                        if(fieldTemplate==null)
                        {
                            // Mapped field no longer found, skipping
                            Logger.LogWarning($"Asset layout {layout.Name} ({layout.ID}) does not contain a field with ID {mapping.AssetFieldID}");
                            continue;
                        }

                        var card = asset.Cards.FirstOrDefault(e => e.IntegratorName == mapping.IntegratorID);
                        if(card==null)
                        {
                            // The current asset does not have the specified integration card
                            Logger.LogDebug($"Asset {asset.Name} ({asset.ID}) does not have a card for integration {mapping.IntegratorID}, skipping");
                            continue;
                        }

                        var cardData = (JsonElement)card.Data;
                        object value = null;
                        bool found = true;
                        foreach(var branch in mapping.CardPath)
                        {
                            if(cardData is JsonElement jsonCardData)
                            {
                                if (!jsonCardData.TryGetProperty(branch, out cardData))
                                {
                                    found = false;
                                    break;
                                }
                            } else
                            {
                                found = false;
                                break;
                            }
                        }
                        if(found)
                        {
                            try
                            {
                                value = await TranslateFieldValue(fieldTemplate, cardData,
                                            asset, fallbackCompany: fallbackCompany);
                            } catch (NotSupportedException ex)
                            {
                                Logger.LogWarning(ex, "Error while translating field value");
                                continue;
                            }
                            if(String.IsNullOrWhiteSpace(value.ToString()))
                            {
                                continue;
                            } else if(value is IEnumerable enumerableded)
                            {
                                if(!enumerableded.Any())
                                {
                                    continue;
                                }
                            }

                        } else
                        {
                            Logger.LogDebug($"Desired card mapping {String.Join(",",mapping.CardPath)} not found on card");
                            continue;
                        }

                        var field = asset.Fields.FirstOrDefault(e => e.Label == fieldTemplate.Label);
                        if(field==null)
                        {
                            field = new FieldValue(fieldTemplate);
                            asset.Fields.Add(field);
                        }
                        if (field.Value != value)
                        {
                            field.Value = value;
                            updated = true;
                        }



                    }

                    if (updated)
                    {
                        await Client.Assets.Update(asset);
                    }

                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error while syncing asset \"{asset.Name}\" ({asset.ID})", ex);
                }
            }
        }
    }
}
