namespace InfoPanelModels.Models
{
    public class Category : BaseItem
    {
        public string CategoryTypeId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string FullPath { get; set; }
        public bool HasChilds { get; set; }
    }
}
