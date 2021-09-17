using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class Accounts : System.Web.UI.Page
    {
        InfoPanelModels.Models.AccountManager Manager;
        MemberManager MemberManager;
        ContractManager ContractManager;

        ObservableCollection<InfoPanelModels.Models.Member> MemberDataSource;
        ObservableCollection<InfoPanelModels.Models.Contract> ContractDataSource;

        protected void Page_Load(object sender, EventArgs e)
        {
            Manager = InfoPanelModels.Models.AccountManager.DefaultManager;
            MemberManager = MemberManager.DefaultManager;
            ContractManager = ContractManager.DefaultManager;

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
            Manager.InsertItem(e.NewValues);

            CancelEditing(sender, e);
        }

        protected void gv_OnRowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Manager.UpdateItem(e.Keys, e.NewValues);

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
            Manager.DeleteItem(e.Keys);

            CancelEditing(sender, e);
        }

        private async Task UpdateData(DevExpress.Web.ASPxGridView gv)
        {
            if (gv == null)
                return;
            MemberDataSource = await MemberManager.GetAllItemsAsync();
            ContractDataSource = await ContractManager.GetAllItemsAsync();


            ((GridViewDataComboBoxColumn)gv.Columns["MemberId"]).PropertiesComboBox.DataSource = MemberDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["ContractId"]).PropertiesComboBox.DataSource = ContractDataSource;

            gv.DataSource = await Manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void gv_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "MemberId")
            {
                (e.Editor as ASPxComboBox).DataSource = MemberDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }
            if (e.Column.FieldName == "ContractId")
            {
                (e.Editor as ASPxComboBox).DataSource = ContractDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

        }
    }
}