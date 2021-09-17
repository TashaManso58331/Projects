namespace InfoPanelModels.Models
{
    public class Route : BaseFakeItem
    {
        public string CrewId { get; set; }
        public string CreatorId { get; set; }
        public string Status { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int Distance { get; set; }
    }
}
