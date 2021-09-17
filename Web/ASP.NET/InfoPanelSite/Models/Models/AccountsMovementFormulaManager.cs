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
    public partial class AccountsMovementFormulaManager : BaseItemManager<AccountsMovementFormula>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["AmsShemaId"] == null || newValues["MovementTypeId"] == null 
                || (newValues["FromAccount"] == null && newValues["ToAccount"] == null)
                || (newValues["FromFormula"] == null && newValues["ToFormula"] == null)
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(AccountsMovementFormula item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.AmsShemaId = newValues["AmsShemaId"].ToString();
            item.MovementTypeId = newValues["MovementTypeId"].ToString();

            item.FromAccount = newValues["FromAccount"]?.ToString();
            item.FromFormula = newValues["FromFormula"]?.ToString();

            item.ToAccount = newValues["ToAccount"]?.ToString();
            item.ToFormula = newValues["ToFormula"]?.ToString();

            item.Description = newValues["Description"]?.ToString();
            try
            {
                item.Order = Convert.ToInt32(newValues["Order"]?.ToString());
            }
            catch
            {
                item.Order = 0;
            }
        }

        static AccountsMovementFormulaManager defaultInstance = new AccountsMovementFormulaManager();

        public static AccountsMovementFormulaManager DefaultManager
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
