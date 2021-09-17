using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class MovementTypeManager : BaseItemManager<MovementType>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(MovementType item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
        }

        static MovementTypeManager defaultInstance = new MovementTypeManager();

        public static MovementTypeManager DefaultManager
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
