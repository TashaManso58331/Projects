using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class Members : System.Web.UI.Page {

        MemberManager manager;
        ObservableCollection<MemberType> MemberTypeDataSource;
        ObservableCollection<Country> CountryDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = MemberManager.DefaultManager;

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
            MemberTypeDataSource = await MemberTypeManager.DefaultManager.GetAllItemsAsync();
            CountryDataSource = await CountryManager.DefaultManager.GetAllItemsAsync();
            ((GridViewDataComboBoxColumn)gv.Columns["MemberTypeId"]).PropertiesComboBox.DataSource = MemberTypeDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["CountryId"]).PropertiesComboBox.DataSource = CountryDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
    }
}