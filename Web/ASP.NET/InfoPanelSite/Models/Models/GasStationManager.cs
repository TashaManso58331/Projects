using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InfoPanelModels.Models
{
    
    public partial class GasStationManager : BaseItemManager<GasStation>
    {
        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (   newValues["Latitude"] == null || newValues["Longitude"] == null                 
                || newValues["CountryId"] == null                 
                )
                    return false;

                return true;
        }

        protected override void UpdateItemBody(GasStation item, IDictionary newValues)
        {
            item.Building = newValues["Building"]?.ToString();
            item.City = newValues["City"]?.ToString();
            item.CountryId = newValues["CountryId"]?.ToString();
            item.Direction = newValues["Direction"]?.ToString();
            item.Extension = newValues["Extension"]?.ToString();
            item.Phone = newValues["Phone"]?.ToString();
            item.ShortName = newValues["ShortName"]?.ToString();
            item.State = newValues["State"]?.ToString();
            item.Street = newValues["Street"]?.ToString();
            item.Zip = newValues["Zip"]?.ToString();

            if (newValues["Latitude"] != null)
                item.Latitude = System.Convert.ToDouble(newValues["Latitude"]);

            if (newValues["Longitude"] != null)
                item.Longitude = System.Convert.ToDouble(newValues["Longitude"]);            
        }

        static GasStationManager defaultInstance = new GasStationManager();

        public static GasStationManager DefaultManager
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

        internal async Task<ObservableCollection<GasStation>> GetGasStationsForChainsAsync(params string[] memberTypes)
        {
            if (memberTypes == null)
                return null;

            try
            {
                // TODO: add api controller on service
                var allChains = await GasStationChainManager.DefaultManager.GetAllItemsAsync();
                if (allChains == null)
                    return null;

                var membersByType = await MemberManager.DefaultManager.GetMembersByTypeAsync(memberTypes);
                if (membersByType == null)
                    return null;

                var membersChains = allChains.Where(c => membersByType.Any(m => m.Id == c.MemberId)).ToList();

                var allGasStations = await GasStationManager.DefaultManager.GetAllItemsAsync();
                if (allGasStations == null)
                    return null;

                var items = allGasStations.Where(g=> membersChains.Any(c=>c.GasStationId == g.Id)).ToList();

                return new ObservableCollection<GasStation>(items);
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

        public async Task<ObservableCollection<GasStation>> GetGasStationsForIssuerChainsAsync()
        {
            return await GetGasStationsForChainsAsync("Issuer");
        }

        public async Task<ObservableCollection<GasStation>> GetGasStationsForSellerChainsAsync()
        {
            return await GetGasStationsForChainsAsync("Fuel Seller");
        }
    }
}