using Newtonsoft.Json;
using System;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for Movement
    /// </summary>
    public class Movement : BaseFakeItem
    {
        [JsonProperty(PropertyName = "movementtypeid")]
        public string MovementTypeId { get; set; }
        [JsonProperty(PropertyName = "movementdatetime")]
        public DateTime MovementDateTime { get; set; }
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
        [JsonProperty(PropertyName = "comment")]
        public String Comment { get; set; }
    }
}
