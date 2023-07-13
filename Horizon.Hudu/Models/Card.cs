using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Horizon.Hudu.Models
{
    public class Card
    {
       

        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("integrator_id")]
        public int IntegratorID { get; set; }
        [JsonPropertyName("integrator_name")]
        public string IntegratorName { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("primary_field")]
        public string PrimaryField { get; set; }
        [JsonPropertyName("data")]
        public Object Data { get; set; }

        
    }
}
