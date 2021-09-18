using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for AmsShema
    /// </summary>
    public class AmsShema : BaseItem
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
