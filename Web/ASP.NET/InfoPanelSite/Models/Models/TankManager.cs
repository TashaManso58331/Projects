using System;
using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class TankManager : BaseFakeItemManager<Tank>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["TruckId"] == null || newValues["Volume"] == null || newValues["TankSide"] == null)
                return false;

            return double.TryParse(newValues["Volume"]?.ToString(), out var value);
        }

        protected override void UpdateItemBody(Tank item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.TruckId = newValues["TruckId"].ToString();
            item.TankSide = newValues["TankSide"]?.ToString();
            try
            {
                item.Volume = Convert.ToDouble(newValues["Volume"]?.ToString());
            }
            catch { item.Volume = 0; }
        }

        static TankManager defaultInstance = new TankManager();

        public static TankManager DefaultManager
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
