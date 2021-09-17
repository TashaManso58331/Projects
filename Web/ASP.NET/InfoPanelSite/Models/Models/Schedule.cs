namespace InfoPanelModels.Models
{
    public class Schedule : BaseItem
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int Count { get; set; }
        public int IntervalMin { get; set; }
    }
}
