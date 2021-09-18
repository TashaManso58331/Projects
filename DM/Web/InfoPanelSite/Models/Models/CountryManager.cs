using System.Collections;

namespace InfoPanelModels.Models
{
    public class CountryManager : BaseItemManager<Country>
    {
        public static CountryManager DefaultManager { get; private set; } = new CountryManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["Code"] == null || newValues["CurrencyId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Country item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"]?.ToString();
            item.Code = newValues["Code"]?.ToString();
            item.CurrencyId = newValues["CurrencyId"]?.ToString();
            item.WireCardCode = newValues["WireCardCode"]?.ToString();
        }
    }
}
