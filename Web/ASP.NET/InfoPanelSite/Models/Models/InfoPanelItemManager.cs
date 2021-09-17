using InfoPanelModels.Common;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InfoPanelModels.Models
{
    public partial class InfoPanelItemManager : BaseFakeItemManager<InfoPanelItem>
    {
        private readonly PriceType CurrentPriceType;

        public InfoPanelItemManager(PriceType priceType)
        {
            this.CurrentPriceType = priceType;
        }

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            return true;
        }

        public static InfoPanelItemManager GasStationInfoPanelItemManager = new InfoPanelItemManager(PriceType.GasStationPrice);
        public static InfoPanelItemManager IssuerPublicInfoPanelItemManager = new InfoPanelItemManager(PriceType.IssuerPublicPrice);
        public static InfoPanelItemManager IssuerSpecialInfoPanelItemManager = new InfoPanelItemManager(PriceType.IssuerSpecialPrice);
        public static InfoPanelItemManager SellerDirectInfoPanelItemManager = new InfoPanelItemManager(PriceType.SellerDirectPrice);
        public static InfoPanelItemManager SellerSpecialInfoPanelItemManager = new InfoPanelItemManager(PriceType.SellerSpecialPrice);

        protected override void UpdateItemBody(InfoPanelItem item, IDictionary newValues)
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
                item.Price = System.Convert.ToDouble(newValues["Price"]);

            if (newValues["BuyerId"] != null)
                item.BuyerId = newValues["BuyerId"].ToString();

            item.PriceType = this.CurrentPriceType.ToString();
        }              

        public override async Task<ObservableCollection<InfoPanelItem>> GetAllItemsAsync(bool syncItems = false)
        {
            try
            {
                var query = todoTable.Where(c=>c.PriceType == this.CurrentPriceType.ToString()).IncludeTotalCount();
                var items = await query./*Take(10000).*/ToListAsync();
                return new ObservableCollection<InfoPanelItem>(items);
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