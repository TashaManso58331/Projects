using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class CrewTruckManager : BaseFakeItemManager<CrewTruck>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["CrewId"] == null || newValues["TruckId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(CrewTruck item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.CrewId = newValues["CrewId"].ToString();
            item.TruckId = newValues["TruckId"].ToString();
        }

        static CrewTruckManager defaultInstance = new CrewTruckManager();

        public static CrewTruckManager DefaultManager
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
