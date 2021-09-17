namespace InfoPanelModels.Models
{
    public class RouteFuelTransactionStep : BaseFakeItem
    {
        public string RouteFuelTransactionId { get; set; }
        public string StepType { get; set; }
        public int OrderNum { get; set; }
        public string Status { get; set; }
        public string AcceptedUserId { get; set; }
        public string Result { get; set; }
        public string FuelTransactionsPatternStepId { get; set; }
    }
}
