using Horizon.Hudu.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Horizon.Hudu.Models
{
    public class Company: IHuduURL
    {
      

        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }
        [JsonPropertyName("address_line_1")]
        public string AddressLine1 { get; set; }
        [JsonPropertyName("address_line_2")]
        public string AddressLine2 { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("zip")]
        public string ZIP { get; set; }
        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("company_type")]
        public string CompanyType { get; set; }
        [JsonPropertyName("parent_company_id")]
        public int? ParentCompanyID { get; set; }
        [JsonPropertyName("parent_company_name")]
        public string ParentCompanyName { get; set; }
        [JsonPropertyName("fax_number")]
        public string FaxNumber { get; set; }
        [JsonPropertyName("website")]
        public string Website { get; set; }
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
        [JsonPropertyName("id_number")]
        public string IDNumber { get; set; }

        [JsonPropertyName("url")]
        public string URL { get; set; }
        [JsonPropertyName("passwords_url")]
        public string PasswordsURL { get; set; }
        [JsonPropertyName("knowledge_base_url")]
        public string KnowledgeBaseURL { get; set; }
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
