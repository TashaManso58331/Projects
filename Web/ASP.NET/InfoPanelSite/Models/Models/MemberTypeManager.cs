using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class MemberTypeManager : BaseItemManager<MemberType>
    {
        public static MemberTypeManager DefaultManager { get; private set; } = new MemberTypeManager();
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["FriendlyName"] == null || newValues["IsVisibleForSignUp"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(MemberType item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
            item.FriendlyName = newValues["FriendlyName"].ToString();
            item.IsVisibleForSignUp = System.Convert.ToBoolean(newValues["IsVisibleForSignUp"].ToString());
        }
    }
}
