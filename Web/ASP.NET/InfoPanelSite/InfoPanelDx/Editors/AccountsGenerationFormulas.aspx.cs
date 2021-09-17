using DevExpress.Web;
using InfoPanelModels.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;

namespace InfoPanelDx.Editors
{
    public partial class AccountsGenerationFormulas : System.Web.UI.Page
    {
        AccountsGenerationFormulaManager Manager;
        MemberTypeManager MemberTypeManager;
        AmsShemaManager AmsShemaManager;

        ObservableCollection<InfoPanelModels.Models.MemberType> MemberTypeDataSource;
        ObservableCollection<InfoPanelModels.Models.AmsShema> AmsShemaDataSource;

        protected void Page_Load(object sender, EventArgs e)
        {
            Manager = AccountsGenerationFormulaManager.DefaultManager;
            MemberTypeManager = MemberTypeManager.DefaultManager;
            AmsShemaManager = AmsShemaManager.DefaultManager;

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
            MemberTypeDataSource = await MemberTypeManager.GetAllItemsAsync();
            AmsShemaDataSource = await AmsShemaManager.GetAllItemsAsync();


            ((GridViewDataComboBoxColumn)gv.Columns["MemberTypeId"]).PropertiesComboBox.DataSource = MemberTypeDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["AmsShemaId"]).PropertiesComboBox.DataSource = AmsShemaDataSource;

            gv.DataSource = await Manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void gv_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "MemberTypeId")
            {
                (e.Editor as ASPxComboBox).DataSource = MemberTypeDataSource;
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