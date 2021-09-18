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
    public partial class Trucks : System.Web.UI.Page {

        TruckManager manager;
        ObservableCollection<InfoPanelModels.Models.Member> MemberDataSource;
        ObservableCollection<InfoPanelModels.Models.FuelType> FuelTypeDataSource;
        ObservableCollection<InfoPanelModels.Models.Injector> InjectorDataSource;
        ObservableCollection<InfoPanelModels.Models.EnumValues> DispencerVehicleTypeDataSource;
        ObservableCollection<InfoPanelModels.Models.EnumValues> PortalDispencersTypeDataSource;
        ObservableCollection<InfoPanelModels.Models.EnumValues> VehicleClassDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = TruckManager.DefaultManager;

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

            MemberDataSource = await MemberManager.DefaultManager.GetFuelBuyerMembersAsync();
            FuelTypeDataSource = await FuelTypeManager.DefaultManager.GetAllItemsAsync();
            InjectorDataSource = await InjectorManager.DefaultManager.GetAllItemsAsync();
            DispencerVehicleTypeDataSource = await EnumsManager.DefaultManager.GetDispencerVehicleTypesAsync();
            PortalDispencersTypeDataSource = await EnumsManager.DefaultManager.GetTruckPortalDispencersTypesAsync();
            VehicleClassDataSource = await EnumsManager.DefaultManager.GetVehicleClassesAsync();

            ((GridViewDataComboBoxColumn)gv.Columns["MemberId"]).PropertiesComboBox.DataSource = MemberDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["FuelTypeId"]).PropertiesComboBox.DataSource = FuelTypeDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["InjectorId"]).PropertiesComboBox.DataSource = InjectorDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["DispencerVehicleType"]).PropertiesComboBox.DataSource = DispencerVehicleTypeDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["PortalDispencersType"]).PropertiesComboBox.DataSource = PortalDispencersTypeDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["VehicleClass"]).PropertiesComboBox.DataSource = VehicleClassDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
    }
}