using InfoPanelModels.Common;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InfoPanelModels.Models
{
    public partial class WireCardCountryManager 
    {
        public static readonly WireCardCountryManager DefaultManager = new WireCardCountryManager();

        protected MobileServiceClient client;
        protected IMobileServiceTable<WireCardCountry> todoTable;

        public async Task<ObservableCollection<WireCardCountry>> GetAllItemsAsync(bool syncItems = false)
        {
            try
            {
                this.client = new MobileServiceClient(DMSettings.Services.PaymentUrl);
                var wireCardCountries = await this.client.InvokeApiAsync<List<WireCardCountry>>("WireCardCountry", System.Net.Http.HttpMethod.Get, 
                    new Dictionary<string,string>());
                return new ObservableCollection<WireCardCountry>(wireCardCountries);
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