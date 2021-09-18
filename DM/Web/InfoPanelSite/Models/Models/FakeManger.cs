namespace InfoPanelModels.Models
{
    public class FakeManger
    {
        public static FakeManger Instance { get; private set; } = new FakeManger();

        public bool IsFake { get; set; }
    }
}
