using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class GasStationChainManager : BaseFakeItemManager<GasStationChain>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["GasStationId"] == null 
                || newValues["MemberId"] == null
                || newValues["VehicleAvailability"] == null
                || newValues["FuelTransactionsPatternId"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(GasStationChain item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.GasStationId = newValues["GasStationId"].ToString();
            item.MemberId = newValues["MemberId"].ToString();
            item.VehicleAvailability = newValues["VehicleAvailability"]?.ToString();
            item.FuelTransactionsPatternId = newValues["FuelTransactionsPatternId"]?.ToString();
        }

        public static GasStationChainManager DefaultManager { get; private set; } = new GasStationChainManager();
    }
}
