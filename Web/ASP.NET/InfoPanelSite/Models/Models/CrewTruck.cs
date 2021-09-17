using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class CrewTruck : BaseFakeItem
    {        
        [JsonProperty(PropertyName = "crewid")]
        public string CrewId { get; set; }
        [JsonProperty(PropertyName = "truckid")]
        public string TruckId { get; set; }
    }
}
