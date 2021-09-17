using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class GasStationCashier : BaseFakeItem
    {        
        [JsonProperty(PropertyName = "gasstationid")]
        public string GasStationId { get; set; }
        [JsonProperty(PropertyName = "cashierid")]
        public string CashierId { get; set; }
    }
}
