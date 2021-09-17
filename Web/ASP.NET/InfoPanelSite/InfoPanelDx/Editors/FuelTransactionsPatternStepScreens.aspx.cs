using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class FuelTransactionsPatternStepScreens : System.Web.UI.Page {

        FuelTransactionsPatternStepScreenManager manager;

        ObservableCollection<FuelTransactionsPatternStep> FuelTransactionsPatternStepDataSource;
        ObservableCollection<Role> RoleDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = FuelTransactionsPatternStepScreenManager.DefaultManager;

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

            FuelTransactionsPatternStepDataSource = await FuelTransactionsPatternStepManager.DefaultManager.GetAllItemsAsync();
            RoleDataSource = await RoleManager.DefaultManager.GetAllItemsAsync();

            ((GridViewDataComboBoxColumn)gv.Columns["FuelTransactionsPatternStepId"]).PropertiesComboBox.DataSource = FuelTransactionsPatternStepDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["RoleId"]).PropertiesComboBox.DataSource = RoleDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
    }
}