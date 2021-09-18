using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class AmsShemaManager : BaseItemManager<AmsShema>
    {
        public static AmsShemaManager DefaultManager { get; set; } = new AmsShemaManager();
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(AmsShema item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
        }
    }
}
