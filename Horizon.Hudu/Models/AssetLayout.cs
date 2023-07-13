using Horizon.Hudu.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Horizon.Hudu.Models
{
    public class AssetLayout
    {
      

        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("icon_color")]
        public string IconColor { get; set; }
        [JsonPropertyName("sidebar_folder_id")]
        public int? SidebarFolderID { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("include_passwords")]
        public bool IncludPasswords { get; set; }
        [JsonPropertyName("include_photos")]
        public bool IncludPhotos{ get; set; }
        [JsonPropertyName("include_comments")]
        public bool IncludComments{ get; set; }
        [JsonPropertyName("include_files")]
        public bool IncludFiles{ get; set; }

        [JsonPropertyName("created_at")]
        public DateTime Created { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime Updated { get; set; }

        [JsonPropertyName("fields")]
        public IList<AssetLayoutField> Fields { get; set; }

    }
}
