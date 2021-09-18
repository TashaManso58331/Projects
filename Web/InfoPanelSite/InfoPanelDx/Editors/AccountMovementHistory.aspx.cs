using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class AccountMovementHistory : System.Web.UI.Page
    {
        AccountMovementManager Manager;
        InfoPanelModels.Models.AccountManager AccountManager;
        MovementManager MovementManager;

        ObservableCollection<InfoPanelModels.Models.Account> AccountDataSource;
        ObservableCollection<InfoPanelModels.Models.Movement> MovementDataSource;

        protected void Page_Load(object sender, EventArgs e)
        {
            Manager = InfoPanelModels.Models.AccountMovementManager.DefaultManager;
            AccountManager = InfoPanelModels.Models.AccountManager.DefaultManager;
            MovementManager = MovementManager.DefaultManager;

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
            Manager.InsertItem(e.NewValues);

            CancelEditing(sender, e);
        }

        protected void gv_OnRowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Manager.UpdateItem(e.Keys, e.NewValues);

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
            Manager.DeleteItem(e.Keys);

            CancelEditing(sender, e);
        }

        private async Task UpdateData(DevExpress.Web.ASPxGridView gv)
        {
            if (gv == null)
                return;
            AccountDataSource = await InfoPanelModels.Models.AccountManager.DefaultManager.GetAllItemsAsync();
            MovementDataSource = await MovementManager.GetAllItemsAsync();


            ((GridViewDataComboBoxColumn)gv.Columns["AccountId"]).PropertiesComboBox.DataSource = AccountDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["MovementId"]).PropertiesComboBox.DataSource = MovementDataSource;

            gv.DataSource = await Manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void gv_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "AccountId")
            {
                (e.Editor as ASPxComboBox).DataSource = AccountDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }
            if (e.Column.FieldName == "MovementId")
            {
                (e.Editor as ASPxComboBox).DataSource = MovementDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

        }
    }
}