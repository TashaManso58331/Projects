using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    public class UserRole : BaseFakeItem
    {    
        [JsonProperty(PropertyName = "userid")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "roleid")]
        public string RoleId { get; set; }
    }
}
