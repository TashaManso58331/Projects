using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class RouteFuelTransactions : System.Web.UI.Page {

        RouteFuelTransactionManager manager;

        ObservableCollection<GasStation> GasStationDataSource;
        ObservableCollection<InfoPanelModels.Models.Member> MemberDataSource;
        ObservableCollection<Fuel> FuelDataSource;
        ObservableCollection<Currency> CurrencyDataSource;
        ObservableCollection<Dispencer> DispencerDataSource;
        ObservableCollection<FuelTransactionsPattern> FuelTransactionsPatternDataSource;
        
        protected void Page_Load(object sender, EventArgs e) {
            manager = RouteFuelTransactionManager.DefaultManager;

            RegisterAsyncTask(new PageAsyncTask(LoadData));
        }

        public async Task LoadData()
        {
            try
            {
                await UpdateData(gv);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void gv_OnRowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            manager.InsertItem(e.NewValues);

            CancelEditing(sender, e);
        }

        protected void gv_OnRowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            manager.UpdateItem(e.Keys, e.NewValues);

            CancelEditing(sender, e);
        }

        private static void CancelEditing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            var g = sender as DevExpress.Web.ASPxGridView;

            if (g != null)
                g.CancelEdit();
        }

        protected void gv_OnRowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            manager.DeleteItem(e.Keys);

            CancelEditing(sender, e);
        }

        private async Task UpdateData(DevExpress.Web.ASPxGridView gv)
        {
            if (gv == null)
                return;

            GasStationDataSource = await GasStationManager.DefaultManager.GetAllItemsAsync();
            MemberDataSource = await MemberManager.DefaultManager.GetAllItemsAsync();
            FuelDataSource = await FuelManager.DefaultManager.GetAllItemsAsync();
            CurrencyDataSource = await CurrencyManager.DefaultManager.GetAllItemsAsync();
            DispencerDataSource = await DispencerManager.DefaultManager.GetAllItemsAsync();
            FuelTransactionsPatternDataSource = await FuelTransactionsPatternManager.DefaultManager.GetAllItemsAsync();


            ((GridViewDataComboBoxColumn)gv.Columns["GasStationId"]).PropertiesComboBox.DataSource = GasStationDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["MemberId"]).PropertiesComboBox.DataSource = MemberDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["FuelId"]).PropertiesComboBox.DataSource = FuelDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["CurrencyId"]).PropertiesComboBox.DataSource = CurrencyDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["DispencerId"]).PropertiesComboBox.DataSource = DispencerDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["FuelTransactionsPatternId"]).PropertiesComboBox.DataSource = FuelTransactionsPatternDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
    }
}