using Horizon.Hudu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Horizon.Hudu.Responses
{
    internal class CompaniesGetResponse
    {
        [JsonPropertyName("companies")]
        public IEnumerable<Company> Companies { get; set; }
    }
}
