using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class DispencerManager : BaseFakeItemManager<Dispencer>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["GasStationId"] == null 
                || newValues["Number"] == null
                || newValues["MemberId"] == null
                || newValues["DispencerVehicleType"] == null || newValues["StationPortalDispencersType"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(Dispencer item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.MemberId = newValues["MemberId"]?.ToString();
            item.GasStationId = newValues["GasStationId"]?.ToString();
            item.Number = newValues["Number"]?.ToString();
            item.DispencerVehicleType = newValues["DispencerVehicleType"]?.ToString();
            item.StationPortalDispencersType = newValues["StationPortalDispencersType"]?.ToString();
        }

        public static DispencerManager DefaultManager { get; private set; } = new DispencerManager();
    }
}
