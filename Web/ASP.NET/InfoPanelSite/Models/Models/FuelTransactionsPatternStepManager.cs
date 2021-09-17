using System.Collections;

namespace InfoPanelModels.Models
{
    public class FuelTransactionsPatternStepManager : BaseItemManager<FuelTransactionsPatternStep>
    {
        public static readonly FuelTransactionsPatternStepManager DefaultManager = new FuelTransactionsPatternStepManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["FuelTransactionsPatternId"] == null
                || newValues["OrderNum"] == null
                || newValues["StepBehavior"] == null
                || newValues["StepType"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(FuelTransactionsPatternStep item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Description = newValues["Description"]?.ToString();
            item.FuelTransactionsPatternId = newValues["FuelTransactionsPatternId"]?.ToString();
            try
            {
                item.OrderNum = System.Convert.ToInt32(newValues["OrderNum"]?.ToString());
            }
            catch { item.OrderNum = 0; }
            item.StepBehavior = newValues["StepBehavior"]?.ToString();
            item.StepType = newValues["StepType"]?.ToString();
        }
    }
}
