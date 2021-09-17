namespace InfoPanelModels.Models
{
    public class FuelTransactionsPatternStep : BaseItem
    {
        public string FuelTransactionsPatternId { get; set; }
        public string Description { get; set; }
        public string StepType { get; set; }
        public int OrderNum { get; set; }
        public string StepBehavior { get; set; }
    }
}
