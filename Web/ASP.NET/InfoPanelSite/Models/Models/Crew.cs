using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class Crew : BaseFakeItem
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "memberid")]
        public string MemberId { get; set; }
    }
}
