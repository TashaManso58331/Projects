using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class NetworkingTitleCategoryManager : BaseItemManager<NetworkingTitleCategory>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(NetworkingTitleCategory item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
        }

        public static NetworkingTitleCategoryManager DefaultManager { get; private set; } = new NetworkingTitleCategoryManager();
    }
}
