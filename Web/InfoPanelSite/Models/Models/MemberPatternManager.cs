using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class MemberPatternManager : BaseFakeItemManager<MemberPattern>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["MemberId"] == null 
                || newValues["FuelTransactionsPatternId"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(MemberPattern item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.MemberId = newValues["MemberId"].ToString();
            item.FuelTransactionsPatternId = newValues["FuelTransactionsPatternId"]?.ToString();
        }

        public static MemberPatternManager DefaultManager { get; private set; } = new MemberPatternManager();
    }
}
