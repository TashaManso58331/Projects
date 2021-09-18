using System.Collections;

namespace InfoPanelModels.Models
{
    
    public partial class AZSManager : BaseItemManager<AZS>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["FullName"] == null || newValues["PublicId"] == null || newValues["GPS_X"] == null || newValues["GPS_Y"] == null || newValues["Address"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(AZS item, IDictionary newValues)
        {
            if (newValues["PublicId"] != null)
                item.PublicId = newValues["PublicId"].ToString();

            if (newValues["ShortName"] != null)
                item.ShortName = newValues["ShortName"].ToString();

            if (newValues["FullName"] != null)
                item.FullName = newValues["FullName"].ToString();

            if (newValues["Phone"] != null)
                item.Phone = newValues["Phone"].ToString();

            if (newValues["Address"] != null)
                item.Address = newValues["Address"].ToString();

            if (newValues["GPS_X"] != null)
                item.GPS_X = System.Convert.ToDouble(newValues["GPS_X"]);

            if (newValues["GPS_Y"] != null)
                item.GPS_Y = System.Convert.ToDouble(newValues["GPS_Y"]);
        }

        static AZSManager defaultInstance = new AZSManager();

        public static AZSManager DefaultManager
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