using Newtonsoft.Json;
using System;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for AccountMovement
    /// </summary>
    public class AccountMovement : BaseFakeItem
    {
        [JsonProperty(PropertyName = "accountid")]
        public string AccountId { get; set; }
        [JsonProperty(PropertyName = "movementid")]
        public string MovementId { get; set; }
        [JsonProperty(PropertyName = "movementdatetime")]
        public DateTime MovementDateTime { get; set; }
        [JsonProperty(PropertyName = "deltaamount")]
        public string DeltaAmount { get; set; }
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }
    }
}
