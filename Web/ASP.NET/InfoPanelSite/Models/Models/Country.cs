namespace InfoPanelModels.Models
{
    public class Country : BaseItem
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string CurrencyId { get; set; }
        public string WireCardCode { get; set; }
    }
}
