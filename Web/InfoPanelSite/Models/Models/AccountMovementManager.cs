using System;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;
using System.Collections.Generic;

namespace InfoPanelModels.Models
{
    public partial class AccountMovementManager : BaseFakeItemManager<AccountMovement>
    {
        static AccountMovementManager defaultInstance = new AccountMovementManager();

        public static AccountMovementManager DefaultManager
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
