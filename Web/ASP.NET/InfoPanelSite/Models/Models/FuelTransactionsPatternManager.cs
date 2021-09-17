using System.Collections;

namespace InfoPanelModels.Models
{
    public class FuelTransactionsPatternManager : BaseItemManager<FuelTransactionsPattern>
    {
        public static readonly FuelTransactionsPatternManager DefaultManager = new FuelTransactionsPatternManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["UserFriendlyName"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(FuelTransactionsPattern item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"]?.ToString();
            item.UserFriendlyName = newValues["UserFriendlyName"]?.ToString();
        }
    }
}
