using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class UserRoleManager : BaseFakeItemManager<UserRole>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            return true;
        }

        protected override void UpdateItemBody(UserRole item, IDictionary newValues)
        {
            if (newValues["UserId"] != null)
                item.UserId = newValues["UserId"].ToString();

            if (newValues["RoleId"] != null)
                item.RoleId = newValues["RoleId"].ToString();            
        }

        static UserRoleManager defaultInstance = new UserRoleManager();

        public static UserRoleManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }
    }
}