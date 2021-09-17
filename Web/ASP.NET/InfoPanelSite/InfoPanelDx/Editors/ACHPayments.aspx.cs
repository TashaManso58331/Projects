using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class ACHPayments : System.Web.UI.Page {

        ACHPaymentManager manager;

        ObservableCollection<InfoPanelModels.Models.Member> MemberBuyerDataSource;
        ObservableCollection<InfoPanelModels.Models.Member> MemberBeneficiaryDataSource;
        ObservableCollection<InfoPanelModels.Models.Currency> CurrencyDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = ACHPaymentManager.DefaultManager;

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
            // call API
            ACHPaymentManager.DefaultManager.SendPayment(e.NewValues);

            CancelEditing(sender, e);
        }

        private static void CancelEditing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            var g = sender as DevExpress.Web.ASPxGridView;

            if (g != null)
                g.CancelEdit();
        }

        private async Task UpdateData(DevExpress.Web.ASPxGridView gv)
        {
            if (gv == null)
                return;
            MemberBuyerDataSource = await MemberManager.DefaultManager.GetFuelBuyerMembersAsync();
            MemberBeneficiaryDataSource = await MemberManager.DefaultManager.GetSellersAsync();
            CurrencyDataSource = await CurrencyManager.DefaultManager.GetAllItemsAsync();

            ((GridViewDataComboBoxColumn)gv.Columns["MemberSenderId"]).PropertiesComboBox.DataSource = MemberBuyerDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["MemberBeneficiaryId"]).PropertiesComboBox.DataSource = MemberBeneficiaryDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["CurrencyId"]).PropertiesComboBox.DataSource = CurrencyDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }
   }
}