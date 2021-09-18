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
    public partial class AccountsGenerationFormulaManager : BaseItemManager<AccountsGenerationFormula>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["MemberTypeId"] == null 
                || newValues["Formula"] == null || newValues["AmsShemaId"] == null)
                return false;

            return true;
        }

        protected override void UpdateItemBody(AccountsGenerationFormula item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
            item.Formula = newValues["Formula"].ToString();
            item.MemberTypeId = newValues["MemberTypeId"].ToString();
            item.AmsShemaId = newValues["AmsShemaId"].ToString();
        }

        static AccountsGenerationFormulaManager defaultInstance = new AccountsGenerationFormulaManager();

        public static AccountsGenerationFormulaManager DefaultManager
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
