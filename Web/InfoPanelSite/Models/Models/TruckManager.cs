using System;
using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class TruckManager : BaseFakeItemManager<Truck>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (
                   newValues["MemberId"] == null
                || newValues["RegistrationNumber"] == null 
                || newValues["Model"] == null
                || newValues["K"] == null
                || newValues["Vstart"] == null
                || newValues["Vcritical"] == null
                || newValues["Vmax"] == null
                || newValues["FuelTypeId"] == null
                || newValues["DispencerVehicleType"] == null
                || newValues["PortalDispencersType"] == null
                || newValues["VehicleClass"] == null                
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(Truck item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.MemberId = newValues["MemberId"].ToString();
            item.RegistrationNumber = newValues["RegistrationNumber"].ToString();
            item.Model = newValues["Model"].ToString();
            item.K = Convert.ToDouble(newValues["K"]);
            item.Vstart = Convert.ToInt32(newValues["Vstart"]);
            item.Vcritical = Convert.ToInt32(newValues["Vcritical"]);
            item.Vmax = Convert.ToInt32(newValues["Vmax"]);
            item.FuelTypeId = newValues["FuelTypeId"]?.ToString();
            item.InjectorId = newValues["InjectorId"]?.ToString();
            item.DispencerVehicleType = newValues["DispencerVehicleType"]?.ToString();
            item.PortalDispencersType = newValues["PortalDispencersType"]?.ToString();
            item.VehicleClass = newValues["VehicleClass"]?.ToString();
        }

        static TruckManager defaultInstance = new TruckManager();

        public static TruckManager DefaultManager
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
