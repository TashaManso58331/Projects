namespace InfoPanelModels.Models
{
    public class FuelTransactionsPatternPayment : BaseItem
    {
        public string FuelTransactionsPatternId { get; set; }
        public string PaymentMethod { get; set; }
        public double PaymentMethodFee { get; set; }
        public string FeeCalcType { get; set; }
    }
}
