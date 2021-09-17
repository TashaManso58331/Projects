using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPanelModels.Models
{
    public class MovementRequest
    {
        [JsonProperty(PropertyName = "movementtypeid")]
        public String MovementTypeId { get; set; }
        [JsonProperty(PropertyName = "amsshemaid")]
        public String AmsShemaId { get; set; }
        [JsonProperty(PropertyName = "memberids")]
        public List<String> MemberIds { get; set; }
        [JsonProperty(PropertyName = "parameters")]
        public Dictionary<String, String> Parameters { get; set; }
    }
}
