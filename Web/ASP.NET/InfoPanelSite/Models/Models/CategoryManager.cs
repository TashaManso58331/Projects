using System;
using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class CategoryManager : BaseItemManager<Category>
    {
        private const int DEFAULT_LEVEL = 0;
        private const bool DEFAULT_HAS_CHILDS = false;

        public static CategoryManager DefaultManager { get; set; } = new CategoryManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["CategoryTypeId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Category item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.CategoryTypeId = newValues["CategoryTypeId"]?.ToString();
            item.Name = newValues["Name"]?.ToString();
            item.ParentId = newValues["ParentId"]?.ToString();
            try
            {
                item.Level = Convert.ToInt32(newValues["Level"]?.ToString());
            }
            catch (Exception ex)
            {
                item.Level = DEFAULT_LEVEL;
            }

            item.FullPath = newValues["FullPath"]?.ToString();
            try
            {
                item.HasChilds = Convert.ToBoolean(newValues["HasChilds"]?.ToString());
            }
            catch (Exception ex)
            {
                item.HasChilds = DEFAULT_HAS_CHILDS;
            }
        }
    }
}
