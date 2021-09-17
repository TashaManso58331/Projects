using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class UserNetworkingTitleManager : BaseItemManager<UserNetworkingTitle>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            return true;
        }

        protected override void UpdateItemBody(UserNetworkingTitle item, IDictionary newValues)
        {
            if (newValues["UserId"] != null)
                item.UserId = newValues["UserId"].ToString();

            if (newValues["NetworkingTitleId"] != null)
                item.NetworkingTitleId = newValues["NetworkingTitleId"].ToString();            
        }

        static UserNetworkingTitleManager defaultInstance = new UserNetworkingTitleManager();

        public static UserNetworkingTitleManager DefaultManager
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