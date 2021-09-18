using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class MemberType : BaseItem
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public bool IsVisibleForSignUp { get; set; }
    }
}
