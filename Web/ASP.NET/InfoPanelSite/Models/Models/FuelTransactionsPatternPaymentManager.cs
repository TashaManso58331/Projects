using System.Collections;

namespace InfoPanelModels.Models
{
    public class FuelTransactionsPatternPaymentManager : BaseItemManager<FuelTransactionsPatternPayment>
    {
        public static readonly FuelTransactionsPatternPaymentManager DefaultManager = new FuelTransactionsPatternPaymentManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["FuelTransactionsPatternId"] == null
                || newValues["PaymentMethodFee"] == null
                || newValues["PaymentMethod"] == null
                || newValues["FeeCalcType"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(FuelTransactionsPatternPayment item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.FuelTransactionsPatternId = newValues["FuelTransactionsPatternId"]?.ToString();
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
