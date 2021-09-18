using System.Collections;

namespace InfoPanelModels.Models
{
    public class FuelTransactionsPatternStepScreenManager : BaseItemManager<FuelTransactionsPatternStepScreen>
    {
        public static readonly FuelTransactionsPatternStepScreenManager DefaultManager = new FuelTransactionsPatternStepScreenManager();
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["FuelTransactionsPatternStepId"] == null
                
                || newValues["RoleId"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(FuelTransactionsPatternStepScreen item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.ButtonText = newValues["ButtonText"]?.ToString();
            item.Description = newValues["Description"]?.ToString();
            item.FuelTransactionsPatternStepId = newValues["FuelTransactionsPatternStepId"]?.ToString();
            item.Name = newValues["Name"]?.ToString();
            item.RoleId = newValues["RoleId"]?.ToString();
            item.PageName = newValues["PageName"]?.ToString();
            item.Title = newValues["Title"]?.ToString();
        }
    }
}
