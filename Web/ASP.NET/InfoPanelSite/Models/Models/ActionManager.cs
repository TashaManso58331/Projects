using System.Collections;

namespace InfoPanelModels.Models
{
    public class ActionManager : BaseItemManager<Action>
    {
        public static ActionManager DefaultManager { get; set; } = new ActionManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            if (newValues["Description"] == null)
                return false;

            if (newValues["GroupName"] == null)
                return false;

            if (newValues["OrderNum"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Action item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"]?.ToString();
            item.Description = newValues["Description"]?.ToString();
            item.GroupName = newValues["GroupName"]?.ToString();
            item.OrderNum = System.Convert.ToInt32(newValues["OrderNum"]?.ToString() ?? 0.ToString());
        }
    }
}
