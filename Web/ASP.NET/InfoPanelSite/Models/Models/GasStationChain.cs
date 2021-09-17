using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class GasStationChain : BaseFakeItem
    {        
        [JsonProperty(PropertyName = "gasstationid")]
        public string GasStationId { get; set; }
        [JsonProperty(PropertyName = "memberid")]
        public string MemberId { get; set; }
        public string VehicleAvailability { get; set; }
        public string FuelTransactionsPatternId { get; set; }
    }
}
