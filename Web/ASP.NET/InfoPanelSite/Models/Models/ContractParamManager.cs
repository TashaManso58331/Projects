using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class ContractParamManager : BaseFakeItemManager<ContractParam>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["ContractId"] == null || newValues["ParamName"] == null || newValues["ParamValue"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(ContractParam item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.ContractId = newValues["ContractId"].ToString();
            item.ParamName = newValues["ParamName"].ToString();
            item.ParamValue = newValues["ParamValue"].ToString();
        }

        static ContractParamManager defaultInstance = new ContractParamManager();

        public static ContractParamManager DefaultManager
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
