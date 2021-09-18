using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoPanelModels.Models
{
    public partial class ContractManager : BaseFakeItemManager<Contract>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Number"] == null 
                || newValues["RegistrationDate"] == null
                || newValues["ExpiryDate"] == null
                || newValues["MemberId"] == null
                || newValues["ContractorId"] == null
                || newValues["AmsShemaId"] == null
                )
                return false;

            return true;
        }

        protected override void UpdateItemBody(Contract item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Number = newValues["Number"].ToString();
            item.RegistrationDate = System.Convert.ToDateTime(newValues["RegistrationDate"]);
            item.ExpiryDate = System.Convert.ToDateTime(newValues["ExpiryDate"]);
            item.MemberId = newValues["MemberId"].ToString();
            item.ContractorId = newValues["ContractorId"].ToString();
            item.AmsShemaId = newValues["AmsShemaId"].ToString();
        }

        static ContractManager defaultInstance = new ContractManager();

        public static ContractManager DefaultManager
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

        public async Task<List<Account>> AccountsGenerate(object Id)
        {
            if (Id == null || String.IsNullOrEmpty(Id.ToString()))
            {
                var emptyList = new List<Account>();
                return emptyList;
            }

            // call for Id
            var parameters = new Dictionary<string, string>() { { "contractId", Id.ToString() } };
            var accounts = await client.InvokeApiAsync<List<Account>>("CreateAccountApi", System.Net.Http.HttpMethod.Get, parameters);
            return accounts;
        }
    }
}

