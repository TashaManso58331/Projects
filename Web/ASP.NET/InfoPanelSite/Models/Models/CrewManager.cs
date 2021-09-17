using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class CrewManager : BaseFakeItemManager<Crew>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["MemberId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(Crew item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
            item.MemberId = newValues["MemberId"].ToString();
        }

        static CrewManager defaultInstance = new CrewManager();

        public static CrewManager DefaultManager
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
