using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class FuelManager : BaseItemManager<Fuel>
    {
        public static FuelManager DefaultManager { get; set; } = new FuelManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Code"] == null || newValues["Remarka"] == null || newValues["FuelTypeId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Fuel item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Code = newValues["Code"].ToString();
            item.Remarka = newValues["Remarka"].ToString();
            item.FuelTypeId = newValues["FuelTypeId"]?.ToString();
            item.InjectorId = newValues["InjectorId"]?.ToString();
            item.SeasonId = newValues["SeasonId"]?.ToString();
        }
    }
}
