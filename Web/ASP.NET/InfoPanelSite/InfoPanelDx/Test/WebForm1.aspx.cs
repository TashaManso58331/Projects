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

namespace InfoPanelDx.Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        GasStationManager manager;
        ObservableCollection<GasStation> GasStationDataSource;

        protected void Page_Load(object sender, EventArgs e)
        {
            manager = GasStationManager.DefaultManager;

            RegisterAsyncTask(new PageAsyncTask(LoadData)); 
        }

        public async Task LoadData()
        {
            try
            {
                GasStationDataSource = await manager.GetAllItemsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task UpdateData(DevExpress.Web.ASPxGridView gv)
        {
            if (gv == null)
                return;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void ASPxGridView1_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "GasStationId")
            { 
                (e.Editor as ASPxComboBox).DataSource = GasStationDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }
        }
    }
}