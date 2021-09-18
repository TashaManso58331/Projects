using InfoPanelModels.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class Schedules : System.Web.UI.Page {

        ScheduleManager manager = ScheduleManager.DefaultManager;

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

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void StartService_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new WebClient();
                var content = client.DownloadString("http://scheduleserviceus.azurewebsites.net/api/TestStartApi?ZUMO-API-VERSION=2.0.0");
                Response.Write("<script LANGUAGE='JavaScript' >alert('" + "Robots are started" + "')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('" + $"Failed to start robots due to {ex.Message}" + "')</script>");
            }
        }
        protected void StopService_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new WebClient();
                var content = client.DownloadString("http://scheduleserviceus.azurewebsites.net/api/TestStopApi?ZUMO-API-VERSION=2.0.0");
                Response.Write("<script LANGUAGE='JavaScript' >alert('" + "Robots are stopped" + "')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('" + $"Failed to stop robots due to {ex.Message}" + "')</script>");
            }
        }
    }
}