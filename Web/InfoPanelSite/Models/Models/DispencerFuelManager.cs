using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class DispencerFuelManager : BaseFakeItemManager<DispencerFuel>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["DispencerId"] == null 
             || newValues["FuelId"] == null 
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(DispencerFuel item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.DispencerId = newValues["DispencerId"]?.ToString();
            item.FuelId = newValues["FuelId"]?.ToString();
        }

        public static DispencerFuelManager DefaultManager { get; private set; } = new DispencerFuelManager();
    }
}
