using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class Contracts : System.Web.UI.Page {

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
    }
}