using Horizon.Hudu.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Horizon.Hudu.Models
{
    public class AssetLayoutField
    {


        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("show_in_list")]
        public bool ShowInList{ get; set; }

        [JsonPropertyName("field_type")]
        public string FieldType { get; set; }

        [JsonPropertyName("required")]
        public bool? Required { get; set; }

        [JsonPropertyName("hint")]
        public string Hint { get; set; }

        [JsonPropertyName("linkable_id")]
        public int LinkableID { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("expiration")]
        public bool Expiration { get; set; }

        [JsonPropertyName("is_destroyed")]
        public bool? IsDestroyed { get; set; }


        public override string ToString()
            => $"{this.Label} ({this.ID})";
    }
}
