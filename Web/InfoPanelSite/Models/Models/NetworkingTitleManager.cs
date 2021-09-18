using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class NetworkingTitleManager : BaseItemManager<NetworkingTitle>
    {
        public static NetworkingTitleManager DefaultManager { get; set; } = new NetworkingTitleManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["NetworkingTitleCategoryId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(NetworkingTitle item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
            item.NetworkingTitleCategoryId = newValues["NetworkingTitleCategoryId"].ToString();
        }
    }
}
