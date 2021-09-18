namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class GasStationChainPatternPayment : BaseFakeItem
    {        
        public string GasStationChainPatternId { get; set; }
        public string PaymentMethod { get; set; }
        public double PaymentMethodFee { get; set; }
        public string FeeCalcType { get; set; }        
    }
}
