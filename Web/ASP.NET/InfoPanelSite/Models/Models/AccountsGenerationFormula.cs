using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for AmsShema
    /// </summary>
    public class AccountsGenerationFormula : BaseItem
    {
        [JsonProperty(PropertyName = "amsshemaid")]
        public string AmsShemaId { get; set; }
        [JsonProperty(PropertyName = "membertypeid")]
        public string MemberTypeId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "formula")]
        public string Formula { get; set; }
    }
}
