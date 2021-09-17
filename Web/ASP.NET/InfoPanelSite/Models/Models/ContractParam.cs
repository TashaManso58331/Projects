using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for ContractParam
    /// </summary>
    public class ContractParam : BaseFakeItem
    {
        [JsonProperty(PropertyName = "contractid")]
        public string ContractId { get; set; }
        [JsonProperty(PropertyName = "paramname")]
        public string ParamName { get; set; }
        [JsonProperty(PropertyName = "paramvalue")]
        public string ParamValue { get; set; }
    }
}
