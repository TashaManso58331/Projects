namespace InfoPanelModels.Models
{
    public class RouteFuelTransactionStepScreen : BaseItem
    {
        public string RouteFuelTransactionStepId { get; set; }
        public string RoleId { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public string PushBefore { get; set; }
        public string PushAfter { get; set; }
        public string AlertMessage { get; set; }
        public string Color { get; set; }
        public string FuelTransactionsPatternStepScreenId { get; set; }
    }
}
