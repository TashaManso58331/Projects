using System.Collections;

namespace InfoPanelModels.Models
{
    public class ActionRoleManager : BaseItemManager<ActionRole>
    {
        public static ActionRoleManager DefaultManager { get; set; } = new ActionRoleManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["ActionId"] == null)
                return false;

            if (newValues["RoleId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(ActionRole item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.ActionId = newValues["ActionId"].ToString();
            item.RoleId = newValues["RoleId"].ToString();
        }
    }
}
