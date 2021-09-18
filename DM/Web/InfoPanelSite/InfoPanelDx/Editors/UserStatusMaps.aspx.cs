using DevExpress.Web;
using InfoPanelModels.Common;
using InfoPanelModels.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class UserStatusMaps : System.Web.UI.Page {

        BaseItemManager<UserStatusMap> manager = UserStatusMapManager.DefaultManager;

        readonly MobileServiceClient client = new MobileServiceClient(DMSettings.Services.InfoPanelUrl);

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

            ((GridViewDataComboBoxColumn)gv.Columns["UserId"]).PropertiesComboBox.DataSource = await UserManager.DefaultManager.GetAllItemsAsync();
            ((GridViewDataComboBoxColumn)gv.Columns["UserStatusId"]).PropertiesComboBox.DataSource = await UserStatusManager.DefaultManager.GetAllItemsAsync();

            gv.DataSource = await UserStatusMapManager.DefaultManager.GetAllItemsAsync();
            gv.DataBind();
        }
    }
}