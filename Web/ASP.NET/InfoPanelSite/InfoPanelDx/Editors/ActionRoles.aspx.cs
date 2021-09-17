using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class ActionRoles : System.Web.UI.Page {

        ActionRoleManager manager;
        ActionManager ActionManager;
        RoleManager RoleManager;

        ObservableCollection<InfoPanelModels.Models.Action> ActionDataSource;
        ObservableCollection<Role> RoleDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = ActionRoleManager.DefaultManager;
            ActionManager = ActionManager.DefaultManager;
            RoleManager = RoleManager.DefaultManager;;

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
            ActionDataSource = await ActionManager.GetAllItemsAsync();
            RoleDataSource = await RoleManager.GetAllItemsAsync();

            ((GridViewDataComboBoxColumn)gv.Columns["ActionId"]).PropertiesComboBox.DataSource = ActionDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["RoleId"]).PropertiesComboBox.DataSource = RoleDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void gv_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "ActionId")
            {
                (e.Editor as ASPxComboBox).DataSource = ActionDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "RoleId")
            {
                (e.Editor as ASPxComboBox).DataSource = RoleDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }            
        }
    }
}