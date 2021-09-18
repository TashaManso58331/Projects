using System;
using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class InjectorManager : BaseItemManager<Injector>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            if (!int.TryParse(newValues["QualityLevel"].ToString(), out int value))
                return false;

            return true;
        }

        protected override void UpdateItemBody(Injector item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
            try
            {
                item.QualityLevel = Convert.ToInt32(newValues["QualityLevel"].ToString());
            }
            catch
            {
                item.QualityLevel = 0;
            }
        }

        static InjectorManager defaultInstance = new InjectorManager();

        public static InjectorManager DefaultManager
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
