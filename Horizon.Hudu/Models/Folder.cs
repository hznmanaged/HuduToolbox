using Horizon.Hudu.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Horizon.Hudu.Models
{
    public class Folder
    {


        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("company_id")]
        public int? CompanyID { get; set; }
        [JsonPropertyName("parent_folder_id")]
        public int? ParentFolderID { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }


        [JsonPropertyName("created_at")]
        public DateTime Created { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime Updated { get; set; }
    }
}
