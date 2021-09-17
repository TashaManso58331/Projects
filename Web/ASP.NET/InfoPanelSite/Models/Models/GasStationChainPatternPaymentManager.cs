using System.Collections;

namespace InfoPanelModels.Models
{
    public class GasStationChainPatternPaymentManager : BaseFakeItemManager<GasStationChainPatternPayment>
    {
        public static readonly GasStationChainPatternPaymentManager DefaultManager = new GasStationChainPatternPaymentManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["GasStationChainPatternId"] == null
                || newValues["PaymentMethodFee"] == null
                || newValues["PaymentMethod"] == null
                || newValues["FeeCalcType"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(GasStationChainPatternPayment item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.GasStationChainPatternId = newValues["GasStationChainPatternId"]?.ToString();
            try
            {
                item.PaymentMethodFee = System.Convert.ToDouble(newValues["PaymentMethodFee"]?.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }
            catch { item.PaymentMethodFee = 0; }
            item.PaymentMethod = newValues["PaymentMethod"]?.ToString();
            item.FeeCalcType = newValues["FeeCalcType"]?.ToString();
        }
    }
}
