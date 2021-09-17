using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class GasStationChainPatternManager : BaseFakeItemManager<GasStationChainPattern>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["GasStationChainId"] == null 
                || newValues["FuelTransactionsPatternId"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(GasStationChainPattern item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.GasStationChainId = newValues["GasStationChainId"].ToString();
            item.FuelTransactionsPatternId = newValues["FuelTransactionsPatternId"]?.ToString();
        }

        public static GasStationChainPatternManager DefaultManager { get; private set; } = new GasStationChainPatternManager();
    }
}
