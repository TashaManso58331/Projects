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
    public partial class Instructions : System.Web.UI.Page {

        InstructionManager manager;
        ObservableCollection<InfoPanelModels.Models.EnumValues> TextTypeDataSource;
        ObservableCollection<InfoPanelModels.Models.EnumValues> CultureInfoDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = InstructionManager.DefaultManager;

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

            TextTypeDataSource = await EnumsManager.DefaultManager.GetTextTypesAsync();
            CultureInfoDataSource = new ObservableCollection<EnumValues>(System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures).Select(c=> new EnumValues { Name = c.Name }));

            ((GridViewDataComboBoxColumn)gv.Columns["TextType"]).PropertiesComboBox.DataSource = TextTypeDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["CultureInfo"]).PropertiesComboBox.DataSource = CultureInfoDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
    }
}