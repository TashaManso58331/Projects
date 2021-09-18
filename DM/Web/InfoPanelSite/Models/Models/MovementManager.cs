using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class MovementManager : BaseFakeItemManager<Movement>
    {
        static MovementManager defaultInstance = new MovementManager();

        public static MovementManager DefaultManager
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
