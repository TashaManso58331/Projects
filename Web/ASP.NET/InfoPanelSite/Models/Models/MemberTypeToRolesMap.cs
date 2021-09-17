using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class MemberTypeToRolesMap : BaseItem
    {
        [JsonProperty(PropertyName = "membertypeid")]
        public string MemberTypeId { get; set; }
        [JsonProperty(PropertyName = "roleid")]
        public string RoleId { get; set; }
    }
}
