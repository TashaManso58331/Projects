using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class CrewDriver : BaseFakeItem
    {
        [JsonProperty(PropertyName = "crewid")]
        public string CrewId { get; set; }
        [JsonProperty(PropertyName = "driverid")]
        public string DriverId { get; set; }
    }
}
