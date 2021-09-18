using InfoPanelModels.Common;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InfoPanelModels.Models
{
    public partial class CashbackManager : BaseFakeItemManager<Cashback>
    {
        public static readonly CashbackManager DefaultManager = new CashbackManager();

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            return true;
        }

        protected override void UpdateItemBody(Cashback item, IDictionary newValues)
        {
            if (newValues["GasStationId"] != null)
                item.GasStationId = newValues["GasStationId"].ToString();

            if (newValues["MemberId"] != null)
                item.MemberId = newValues["MemberId"].ToString();

            if (newValues["FuelId"] != null)
                item.FuelId = newValues["FuelId"].ToString();

            if (newValues["CurrencyId"] != null)
                item.CurrencyId = newValues["CurrencyId"].ToString();

            item.PublishDateTime = System.DateTime.Now;

            if (newValues["Price"] != null)
                item.Formula = newValues["Formula"]?.ToString();

            if (newValues["BuyerId"] != null)
                item.BuyerId = newValues["BuyerId"].ToString();
        }              

        public override async Task<ObservableCollection<Cashback>> GetAllItemsAsync(bool syncItems = false)
        {
            try
            {
                var query = todoTable.IncludeTotalCount();
                var items = await query./*Take(10000).*/ToListAsync();
                return new ObservableCollection<Cashback>(items);
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