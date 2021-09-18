using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class CategoryTypeManager : BaseItemManager<CategoryType>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(CategoryType item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
        }

        public static CategoryTypeManager DefaultManager { get; private set; } = new CategoryTypeManager();
    }
}
