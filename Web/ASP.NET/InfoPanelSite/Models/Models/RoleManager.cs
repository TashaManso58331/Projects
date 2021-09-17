using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class RoleManager : BaseItemManager<Role>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["MemberTypeId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Role item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
            item.MemberTypeId = newValues["MemberTypeId"].ToString();
        }

        static RoleManager defaultInstance = new RoleManager();

        public static RoleManager DefaultManager
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
