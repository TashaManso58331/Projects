namespace InfoPanelModels.Models
{
    public class RouteFuelTransaction : BaseFakeItem
    {
        public string RouteId { get; set; }
        public string GasStationId { get; set; }
        public string MemberId { get; set; }
        public string FuelId { get; set; }
        public string CurrencyId { get; set; }
        public string PriceType { get; set; }
        public double Price { get; set; }
        public double Distance { get; set; }
        public double FuelAmount { get; set; }
        public double FuelCost { get; set; }
        public string Status { get; set; }
        public int OrderNum { get; set; }
        public string DispencerId { get; set; }
        public string FuelTransactionsPatternId { get; set; }
    }
}
