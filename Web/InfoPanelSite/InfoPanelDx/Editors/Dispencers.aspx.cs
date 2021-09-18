using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class Dispencers : System.Web.UI.Page {

        DispencerManager manager = DispencerManager.DefaultManager;
        ObservableCollection<InfoPanelModels.Models.Member> MemberDataSource;
        ObservableCollection<InfoPanelModels.Models.GasStation> GasStationDataSource;
        ObservableCollection<InfoPanelModels.Models.EnumValues> DispencerVehicleTypeDataSource;
        ObservableCollection<InfoPanelModels.Models.EnumValues> StationPortalDispencersTypeDataSource;

        protected void Page_Load(object sender, EventArgs e) {
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

            DispencerVehicleTypeDataSource = await EnumsManager.DefaultManager.GetDispencerVehicleTypesAsync();
            StationPortalDispencersTypeDataSource = await EnumsManager.DefaultManager.GetStationPortalDispencersTypeAsync();
            MemberDataSource = await MemberManager.DefaultManager.GetAllItemsAsync();
            GasStationDataSource = await GasStationManager.DefaultManager.GetAllItemsAsync();
            
            ((GridViewDataComboBoxColumn)gv.Columns["MemberId"]).PropertiesComboBox.DataSource = MemberDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["GasStationId"]).PropertiesComboBox.DataSource = GasStationDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["DispencerVehicleType"]).PropertiesComboBox.DataSource = DispencerVehicleTypeDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["StationPortalDispencersType"]).PropertiesComboBox.DataSource = StationPortalDispencersTypeDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
    }
}