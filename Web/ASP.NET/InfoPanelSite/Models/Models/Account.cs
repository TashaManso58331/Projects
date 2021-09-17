using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for AmsShema
    /// </summary>
    public class Account : BaseFakeItem
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        public double Amount { get; set; }
        [JsonProperty(PropertyName = "memberid")]
        public string MemberId { get; set; }
        [JsonProperty(PropertyName = "contractid")]
        public string ContractId { get; set; }
        public int Status { get; set; }
        public int AccountType { get; set; }
    }
}
