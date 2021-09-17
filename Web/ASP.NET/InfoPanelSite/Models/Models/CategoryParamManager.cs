using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class CategoryParamManager : BaseItemManager<CategoryParam>
    {
        public static CategoryParamManager DefaultManager { get; set; } = new CategoryParamManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["CategoryId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(CategoryParam item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.CategoryId = newValues["CategoryId"]?.ToString();
            item.Name = newValues["Name"]?.ToString();
        }
    }
}
