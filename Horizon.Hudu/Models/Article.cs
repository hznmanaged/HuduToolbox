using Horizon.Hudu.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Horizon.Hudu.Models
{
    public class Article: IHuduURL
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("company_id")]
        public int? CompanyID { get; set; }
        [JsonPropertyName("folder_id")]
        public int? FolderID { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("draft")]
        public bool? Draft { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("url")]
        public string URL { get; set; }
        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; }
        [JsonPropertyName("archived")]
        public bool Archived { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime Created { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime Updated { get; set; }
    }
}
