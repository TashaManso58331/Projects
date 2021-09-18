using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    public class AZS : BaseItem
    {
        [JsonProperty(PropertyName = "publicid")]
        public string PublicId { get; set; }

        [JsonProperty(PropertyName = "shortname")]
        public string ShortName { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "phone")]  
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "gps_x")]
        public double GPS_X { get; set; }

        [JsonProperty(PropertyName = "gps_y")]
        public double GPS_Y { get; set; }
    }
}
