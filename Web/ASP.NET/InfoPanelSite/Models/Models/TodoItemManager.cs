using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class TodoItemManager : BaseItemManager<TodoItem>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(TodoItem item, IDictionary newValues)
        {
            item.Name = newValues["Name"].ToString();
        }

        static TodoItemManager defaultInstance = new TodoItemManager();

        public static TodoItemManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }
    }
}