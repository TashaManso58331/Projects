using Newtonsoft.Json;
using System;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class Contract : BaseFakeItem
    {
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }
        [JsonProperty(PropertyName = "registrationdate")]
        public DateTime RegistrationDate { get; set; }
        [JsonProperty(PropertyName = "expirydate")]
        public DateTime? ExpiryDate { get; set; }
        [JsonProperty(PropertyName = "memberid")]
        public string MemberId { get; set; }
        [JsonProperty(PropertyName = "contractorid")]
        public string ContractorId { get; set; }
        [JsonProperty(PropertyName = "amsshemaid")]
        public string AmsShemaId { get; set; }
    }
}
