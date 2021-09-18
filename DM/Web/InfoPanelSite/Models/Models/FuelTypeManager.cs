using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class FuelTypeManager : BaseItemManager<FuelType>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(FuelType item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
        }

        public static FuelTypeManager DefaultManager { get; private set; } = new FuelTypeManager();
    }
}
