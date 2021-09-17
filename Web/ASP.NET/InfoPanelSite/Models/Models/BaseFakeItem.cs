namespace InfoPanelModels.Models
{
    public class BaseFakeItem : BaseItem
    {
        public bool Fake { get; set; }

        public override bool HasFake()
        {
            return true;
        }
    }
}
