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
    public partial class CrewTrucks : System.Web.UI.Page {

        CrewTruckManager manager;
        CrewManager CrewManager;
        TruckManager TruckManager;

        ObservableCollection<Crew> CrewDataSource;
        ObservableCollection<Truck> TruckDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = CrewTruckManager.DefaultManager;
            CrewManager = CrewManager.DefaultManager;
            TruckManager = TruckManager.DefaultManager;;

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
            CrewDataSource = await CrewManager.GetAllItemsAsync();
            TruckDataSource = await TruckManager.GetAllItemsAsync();

            ((GridViewDataComboBoxColumn)gv.Columns["CrewId"]).PropertiesComboBox.DataSource = CrewDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["TruckId"]).PropertiesComboBox.DataSource = TruckDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void gv_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "CrewId")
            {
                (e.Editor as ASPxComboBox).DataSource = CrewDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "TruckId")
            {
                (e.Editor as ASPxComboBox).DataSource = TruckDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }            
        }
    }
}