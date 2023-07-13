using Horizon.Hudu.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Horizon.Hudu.Models
{
    public class FieldValue
    {



        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("value")]
        public Object Value { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        public FieldValue() { }

        public FieldValue(AssetLayoutField assetLayoutField)
        {
            this.ID = assetLayoutField.ID;
            this.Label = assetLayoutField.Label;
        }

    }
}
