using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class AccountsGenerator : System.Web.UI.Page {

        ContractManager manager;
        MemberManager MemberManager;
        MemberManager ContractorManager;
        AmsShemaManager AmsShemaManager;

        ObservableCollection<InfoPanelModels.Models.Member> MemberDataSource;
        ObservableCollection<InfoPanelModels.Models.Member> ContractorDataSource;
        ObservableCollection<AmsShema> AmsShemaDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = ContractManager.DefaultManager;
            MemberManager = MemberManager.DefaultManager;
            ContractorManager = MemberManager.DefaultManager;
            AmsShemaManager = AmsShemaManager.DefaultManager;;

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
            MemberDataSource = await MemberManager.GetAllItemsAsync();
            ContractorDataSource = await MemberManager.GetAllItemsAsync();
            AmsShemaDataSource = await AmsShemaManager.GetAllItemsAsync();

            ((GridViewDataComboBoxColumn)gv.Columns["MemberId"]).PropertiesComboBox.DataSource = MemberDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["ContractorId"]).PropertiesComboBox.DataSource = ContractorDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["AmsShemaId"]).PropertiesComboBox.DataSource = AmsShemaDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
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

            if (e.Column.FieldName == "ContractorId")
            {
                (e.Editor as ASPxComboBox).DataSource = ContractorDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "AmsShemaId")
            {
                (e.Editor as ASPxComboBox).DataSource = AmsShemaDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }            
        }

        protected async void grid_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID != "Generate") return;

            try
            {
                var contractName = gv.GetRowValues(e.VisibleIndex, "Name");
                var accounts = await manager.AccountsGenerate(gv.GetRowValues(e.VisibleIndex, "Id"));

                //Response.Write("<script>alert('Generated " + accounts.Count + " accounts for " + contractName + "');</script>");
            }
            catch (Exception ex)
            {
                Trace.Warn("AccountsGenerate failed due to " + ex.ToString());
            }
        }
    }
}