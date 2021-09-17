using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class SeasonManager : BaseItemManager<Season>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Season item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
        }

        public static SeasonManager DefaultManager { get; private set; } = new SeasonManager();
    }
}
