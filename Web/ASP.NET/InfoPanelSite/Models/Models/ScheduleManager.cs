using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class ScheduleManager : BaseItemManager<Schedule>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["Count"] == null 
                || newValues["IntervalMin"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Schedule item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"]?.ToString();
            try
            {
                item.IntervalMin = System.Convert.ToInt32(newValues["IntervalMin"]?.ToString());
            }
            catch
            {
                item.IntervalMin = 60;
            }
            try
            {
                item.Count = System.Convert.ToInt32(newValues["Count"]?.ToString());
            }
            catch
            {
                item.Count = 1;
            }
            try
            {
                item.Enabled = System.Convert.ToBoolean(newValues["Enabled"]?.ToString());
            }
            catch
            {
                item.Enabled = false;
            }
        }

        public static ScheduleManager DefaultManager { get; private set; } = new ScheduleManager();
    }
}
