using Horizon.Hudu.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Horizon.Hudu.Models
{
    public class Asset: IHuduURL
    {
      
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("company_id")]
        public int CompanyID { get; set; }
        [JsonPropertyName("asset_layout_id")]
        public int AssetLayoutID { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("primary_serial")]
        public string PrimarySerial { get; set; }
        [JsonPropertyName("primary_mail")]
        public string PrimaryMail { get; set; }

        [JsonPropertyName("primary_model")]
        public string PrimaryModel { get; set; }

        [JsonPropertyName("primary_manufacturer")]
        public string PrimaryManufacturer { get; set; }





        [JsonPropertyName("url")]
        public string URL { get; set; }
        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; }
        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }
        [JsonPropertyName("archived")]
        public bool Archived { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime Created { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime Updated { get; set; }

        [JsonPropertyName("cards")]
        public IList<Card> Cards { get; set; }
        [JsonPropertyName("fields")]
        public IList<FieldValue> Fields { get; set; }

        public Asset()
        {
            this.Fields = new List<FieldValue>();
        }

        public Dictionary<string, object> ToReferenceMap()
        {
            var uri = new Uri(this.URL);

            var urlString = uri.IsAbsoluteUri ? uri.PathAndQuery : uri.OriginalString; 
            return new Dictionary<string, object>() {
                                {"id", this.ID},
                                {"url", urlString},
                                {"name", this.Name},
                            };
        }
    }
}
