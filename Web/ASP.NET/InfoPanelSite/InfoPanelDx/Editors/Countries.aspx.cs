using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class Countries : System.Web.UI.Page {

        CountryManager manager;
        ObservableCollection<Currency> CurrencyDataSource;
        ObservableCollection<WireCardCountry> WireCardCountryDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = CountryManager.DefaultManager;

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

            CurrencyDataSource = await CurrencyManager.DefaultManager.GetAllItemsAsync();
            WireCardCountryDataSource = await WireCardCountryManager.DefaultManager.GetAllItemsAsync();

            ((GridViewDataComboBoxColumn)gv.Columns["CurrencyId"]).PropertiesComboBox.DataSource = CurrencyDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["WireCardCode"]).PropertiesComboBox.DataSource = WireCardCountryDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
    }
}