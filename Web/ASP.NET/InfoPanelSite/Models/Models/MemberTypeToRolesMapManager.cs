using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class MemberTypeToRolesMapManager : BaseItemManager<MemberTypeToRolesMap>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["MemberTypeId"] == null || newValues["RoleId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(MemberTypeToRolesMap item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.MemberTypeId = newValues["MemberTypeId"].ToString();
            item.RoleId = newValues["RoleId"].ToString();
        }

        static MemberTypeToRolesMapManager defaultInstance = new MemberTypeToRolesMapManager();

        public static MemberTypeToRolesMapManager DefaultManager
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
