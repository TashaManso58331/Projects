using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class ACHBalanceManager : BaseFakeItemManager<ACHBalance>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["MemberId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(ACHBalance item, IDictionary newValues)
        {
            return;
        }

        public static ACHBalanceManager DefaultManager { get; private set; } = new ACHBalanceManager();
    }
}
