using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class GasStationCashierManager : BaseFakeItemManager<GasStationCashier>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["GasStationId"] == null || newValues["CashierId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(GasStationCashier item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.GasStationId = newValues["GasStationId"].ToString();
            item.CashierId = newValues["CashierId"].ToString();
        }

        static GasStationCashierManager defaultInstance = new GasStationCashierManager();

        public static GasStationCashierManager DefaultManager
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
