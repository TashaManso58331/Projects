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
    public partial class IssuerSpecialInfoPanelItems : System.Web.UI.Page {

        InfoPanelItemManager manager;
        GasStationManager GasStationmanager;
        MemberManager MemberManager;
        MemberTypeManager MemberTypeManager;
        FuelManager FuelManager;
        CurrencyManager CurrencyManager;

        ObservableCollection<GasStation> GasStationDataSource;
        ObservableCollection<InfoPanelModels.Models.Member> MemberDataSource;
        ObservableCollection<InfoPanelModels.Models.Member> BuyerDataSource;
        ObservableCollection<InfoPanelModels.Models.MemberType> MemberTypeDataSource;
        ObservableCollection<Fuel> FuelDataSource;
        ObservableCollection<Currency> CurrencyDataSource;

        protected void Page_Load(object sender, EventArgs e) {
            manager = InfoPanelItemManager.IssuerSpecialInfoPanelItemManager;
            GasStationmanager = GasStationManager.DefaultManager;
            MemberManager = MemberManager.DefaultManager;            
            MemberTypeManager = MemberTypeManager.DefaultManager;
            FuelManager = FuelManager.DefaultManager;
            CurrencyManager = CurrencyManager.DefaultManager;

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
            GasStationDataSource = await GasStationmanager.GetGasStationsForIssuerChainsAsync();
            MemberDataSource = await MemberManager.GetIssuersAsync();
            MemberTypeDataSource = await MemberTypeManager.GetAllItemsAsync();
            FuelDataSource = await FuelManager.GetAllItemsAsync();
            CurrencyDataSource = await CurrencyManager.GetAllItemsAsync();
            BuyerDataSource = await MemberManager.GetFuelBuyerMembersAsync();
            
            ((GridViewDataComboBoxColumn)gv.Columns["GasStationId"]).PropertiesComboBox.DataSource = GasStationDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["MemberId"]).PropertiesComboBox.DataSource = MemberDataSource;//.Where(c => c.MemberTypeId == MemberTypeDataSource.FirstOrDefault(ct => ct.EnumValue == "FuelSeller" || ct.EnumValue == "Issuer")?.Id);
            ((GridViewDataComboBoxColumn)gv.Columns["FuelId"]).PropertiesComboBox.DataSource = FuelDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["CurrencyId"]).PropertiesComboBox.DataSource = CurrencyDataSource;
            ((GridViewDataComboBoxColumn)gv.Columns["BuyerId"]).PropertiesComboBox.DataSource = BuyerDataSource;

            gv.DataSource = await manager.GetAllItemsAsync();
            gv.DataBind();
        }

        protected void gv_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "GasStationId")
            {
                (e.Editor as ASPxComboBox).DataSource = GasStationDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "MemberId")
            {
                (e.Editor as ASPxComboBox).DataSource = MemberDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "FuelId")
            {
                (e.Editor as ASPxComboBox).DataSource = FuelDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "CurrencyId")
            {
                (e.Editor as ASPxComboBox).DataSource = CurrencyDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }

            if (e.Column.FieldName == "BuyerId")
            {
                (e.Editor as ASPxComboBox).DataSource = BuyerDataSource;
                (e.Editor as ASPxComboBox).ValueType = typeof(string);
                (e.Editor as ASPxComboBox).DataBind();
            }
        }
    }
}