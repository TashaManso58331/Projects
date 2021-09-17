using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class CrewDriverManager : BaseFakeItemManager<CrewDriver>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["CrewId"] == null || newValues["DriverId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(CrewDriver item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.CrewId = newValues["CrewId"].ToString();
            item.DriverId = newValues["DriverId"].ToString();
        }

        static CrewDriverManager defaultInstance = new CrewDriverManager();

        public static CrewDriverManager DefaultManager
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
