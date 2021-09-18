using System.Collections;

namespace InfoPanelModels.Models
{
    public class UserStatusMapManager : BaseItemManager<UserStatusMap>
    {
        public static UserStatusMapManager DefaultManager { get; set; } = new UserStatusMapManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["UserId"] == null)
                return false;

            if (newValues["UserStatusId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(UserStatusMap item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.UserId = newValues["UserId"]?.ToString();
            item.UserStatusId = newValues["UserStatusId"]?.ToString();
        }
    }
}
