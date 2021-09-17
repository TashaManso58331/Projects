using System.Collections;

namespace InfoPanelModels.Models
{
    public class UserStatusManager : BaseItemManager<UserStatus>
    {
        public static UserStatusManager DefaultManager { get; set; } = new UserStatusManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            if (newValues["Description"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(UserStatus item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"]?.ToString();
            item.Description = newValues["Description"]?.ToString();
        }
    }
}
