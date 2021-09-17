using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class ACHBalanceSellers : System.Web.UI.Page {

        ACHBalanceSellersManager manager;
        ObservableCollection<InfoPanelModels.Models.Member> MemberDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = ACHBalanceSellersManager.DefaultManager;

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

        private async Task UpdateData(DevExpress.Web.ASPxGridView gv)
        {
            if (gv == null)
                return;
            MemberDataSource = await MemberManager.DefaultManager.GetSellersAsync();
            ((GridViewDataComboBoxColumn)gv.Columns["MemberBeneficiaryId"]).PropertiesComboBox.DataSource = MemberDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
   }
}