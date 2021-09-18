using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class CurrencyManager : BaseItemManager<Currency>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["ShortName"] == null || newValues["FullName"] == null || newValues["TextCode"] == null || newValues["NumCode"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Currency item, IDictionary newValues)
        {
            item.TextCode = newValues["TextCode"].ToString();
            item.ShortName = newValues["ShortName"].ToString();
            item.FullName = newValues["FullName"].ToString();
            item.NumCode = System.Convert.ToInt32(newValues["NumCode"]);
        }

        static CurrencyManager defaultInstance = new CurrencyManager();

        public static CurrencyManager DefaultManager
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