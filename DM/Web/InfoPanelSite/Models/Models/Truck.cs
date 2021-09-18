using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class Truck : BaseFakeItem
    {
       [JsonProperty(PropertyName = "registrationnumber")]
        public string RegistrationNumber { get; set; }
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }
        [JsonProperty(PropertyName = "vcritical")]
        public int Vcritical { get; set; }
        [JsonProperty(PropertyName = "vmax")]
        public int Vmax { get; set; }
        [JsonProperty(PropertyName = "vstart")]
        public int Vstart { get; set; }
        [JsonProperty(PropertyName = "k")]
        public double K { get; set; }
        [JsonProperty(PropertyName = "memberid")]
        public string MemberId { get; set; }
        public string FuelTypeId { get; set; }
        public string InjectorId { get; set; }
        public string DispencerVehicleType { get; set; }
        public string PortalDispencersType { get; set; }
        public string VehicleClass { get; set; }
    }
}
