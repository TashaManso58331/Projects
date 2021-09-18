namespace InfoPanelModels.Models
{
    public partial class AccountManager : BaseFakeItemManager<Account>
    {
        static AccountManager defaultInstance = new AccountManager();

        public static AccountManager DefaultManager
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
