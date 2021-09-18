using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfoPanelDx.Editors
{
    public partial class Fuels : System.Web.UI.Page {

        FuelManager manager;

        ObservableCollection<FuelType> FuelTypeDataSource;
        ObservableCollection<Injector> InjectorDataSource;
        ObservableCollection<Season> SeasonDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = FuelManager.DefaultManager;

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

            FuelTypeDataSource = await FuelTypeManager.DefaultManager.GetAllItemsAsync();
            InjectorDataSource = await InjectorManager.DefaultManager.GetAllItemsAsync();
            SeasonDataSource = await SeasonManager.DefaultManager.GetAllItemsAsync();

            ((GridViewDataComboBoxColumn)gv.Columns["FuelTypeId"]).PropertiesComboBox.DataSource = FuelTypeDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["InjectorId"]).PropertiesComboBox.DataSource = InjectorDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["SeasonId"]).PropertiesComboBox.DataSource = SeasonDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void gv_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "FuelTypeId")
            {
                (e.Editor as ASPxComboBox).DataSource = FuelTypeDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "InjectorId")
            {
                (e.Editor as ASPxComboBox).DataSource = InjectorDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "SeasonId")
            {
                (e.Editor as ASPxComboBox).DataSource = SeasonDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }
        }
    }
}