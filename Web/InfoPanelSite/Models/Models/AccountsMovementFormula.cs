using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for AmsShema
    /// </summary>
    public class AccountsMovementFormula : BaseItem
    {
        [JsonProperty(PropertyName = "amsshemaid")]
        public string AmsShemaId { get; set; }
        [JsonProperty(PropertyName = "movementtypeid")]
        public string MovementTypeId { get; set; }
        [JsonProperty(PropertyName = "fromaccount")]
        public string FromAccount { get; set; }
        [JsonProperty(PropertyName = "fromformula")]
        public string FromFormula { get; set; }
        [JsonProperty(PropertyName = "toaccount")]
        public string ToAccount { get; set; }
        [JsonProperty(PropertyName = "toformula")]
        public string ToFormula { get; set; }
        [JsonProperty(PropertyName = "order")]
        public int Order { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }        
    }
}
