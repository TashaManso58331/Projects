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
    public partial class MemberManager : BaseFakeItemManager<Member>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["MemberTypeId"] == null
             || newValues["CountryId"] == null
            )
             return false;

            return true;
        }

        protected override void UpdateItemBody(Member item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"]?.ToString();
            item.MemberTypeId = newValues["MemberTypeId"]?.ToString();

            item.Building = newValues["Building"]?.ToString();
            item.City = newValues["City"]?.ToString();
            item.CountryId = newValues["CountryId"]?.ToString();
            item.Extension = newValues["Extension"]?.ToString();
            item.State = newValues["State"]?.ToString();
            item.Street = newValues["Street"]?.ToString();
            item.Zip = newValues["Zip"]?.ToString();

            item.RegistrationNumber = newValues["RegistrationNumber"]?.ToString();
            item.TaxNumber = newValues["TaxNumber"]?.ToString();
            item.VATNumber = newValues["VATNumber"]?.ToString();
            item.BIC = newValues["BIC"]?.ToString();
            item.BankName = newValues["BankName"]?.ToString();
            item.BankAccount = newValues["BankAccount"]?.ToString();

            item.Phone = newValues["Phone"]?.ToString();

            item.MerchantId = newValues["MerchantId"]?.ToString();
            item.MerchantMCC = newValues["MerchantMCC"]?.ToString();
            item.BankCity = newValues["BankCity"]?.ToString();
            item.BankOwner = newValues["BankOwner"]?.ToString();
        }

        public static MemberManager DefaultManager { get; private set; } = new MemberManager();

        public async Task<ObservableCollection<Member>> GetMembersForChainsAsync()
        {
            try
            {
                // TODO: add api controller on service
                var allChains = await GasStationChainManager.DefaultManager.GetAllItemsAsync();

                var allMembers = await MemberManager.DefaultManager.GetAllItemsAsync();

                var items = allMembers.Where(g => allChains.Any(c => c.MemberId == g.Id)).ToList();

                return new ObservableCollection<Member>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task<ObservableCollection<Member>> GetFuelBuyerMembersAsync()
        {
            return await GetMembersByTypeAsync("ATC Buyer", "Self Employed Driver", "Customer");
        }

        public async Task<ObservableCollection<Member>> GetSellersAndIssuersAsync()
        {
            return await GetMembersByTypeAsync("Issuer", "Fuel Seller");
        }

        public async Task<ObservableCollection<Member>> GetIssuersAsync()
        {
            return await GetMembersByTypeAsync("Issuer");           
        }

        public async Task<ObservableCollection<Member>> GetSellersAsync()
        {
            return await GetMembersByTypeAsync("Fuel Seller");
        }

        internal async Task<ObservableCollection<Member>> GetMembersByTypeAsync(params string[] memberTypes)
        {
            if (memberTypes == null)
                return null;

            try
            {
                // TODO: add api controller on service
                var allMemberTypesIds = (await MemberTypeManager.DefaultManager.GetAllItemsAsync())
                    .Where(c => memberTypes.Select(d=>d.ToString())
                                .Contains( c.Name))
                    .Select(c => c.Id)
                    .ToList();

                var items = await MemberManager.DefaultManager.todoTable.Where(c=> allMemberTypesIds.Contains(c.MemberTypeId) && c.Fake == FakeManger.Instance.IsFake).ToListAsync();
                return new ObservableCollection<Member>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }
    }
}
