using DevExpress.Web;
using InfoPanelModels.Common;
using InfoPanelModels.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;
using System.Web;
using System.Text.RegularExpressions;

namespace InfoPanelDx.Editors
{
    public partial class AccountMovementDemo : System.Web.UI.Page
    {
        InfoPanelModels.Models.AccountManager Manager;
        MemberManager MemberManager;
        ContractManager ContractManager;
        MovementTypeManager MovementTypeManager;

        ObservableCollection<InfoPanelModels.Models.Member> MemberDataSource;
        ObservableCollection<Contract> ContractDataSource;
        ObservableCollection<MovementType> MovementTypeSource;

        readonly MobileServiceClient client = new MobileServiceClient(DMSettings.Services.InfoPanelUrl);

        protected void Page_Load(object sender, EventArgs e)
        {
            Manager = InfoPanelModels.Models.AccountManager.DefaultManager;
            MemberManager = MemberManager.DefaultManager;
            ContractManager = ContractManager.DefaultManager;
            MovementTypeManager = MovementTypeManager.DefaultManager;

            RegisterAsyncTask(new PageAsyncTask(LoadData));
        }

        public async Task LoadData()
        {
            try
            {
                //await UpdateData(gv);
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
            MovementTypeSource = await MovementTypeManager.GetAllItemsAsync();

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

        public async void RunClick(object sender, EventArgs args)
        {
            try
            {
                List<object> values = gvMembers.GetSelectedFieldValues("Id");
                if (values.Count == 0 || values[0] == null)
                {
                    return;
                }

                var movementrequest = new MovementRequest()
                {
                    AmsShemaId = cbAmsSchema.SelectedItem?.Value?.ToString(),
                    MemberIds = values?.Select(c => c.ToString()).ToList(),
                    MovementTypeId = cbMovementType.SelectedItem?.Value?.ToString(),
                    Parameters = ParseLines()
                };
                var parameters = new Dictionary<string, string> { { "movementrequeststr", HttpUtility.UrlEncode(JsonConvert.SerializeObject(movementrequest)) } };

                var sendRes = await client.InvokeApiAsync<string>("accountmovementapi", System.Net.Http.HttpMethod.Get, parameters);
                Console.WriteLine($"movement type returned result:{sendRes}");
                Response.Write("<script LANGUAGE='JavaScript' >alert('"+$"movement type returned result:{ sendRes}"+"')</script>");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Response.Write("<script LANGUAGE='JavaScript' >alert('" + $"movement type failed with Error:{ ex.ToString()}" + "')</script>");
            }
            finally
            {
                RegisterAsyncTask(new PageAsyncTask(LoadData));
            }
        }

        private Dictionary<String, String> ParseLines()
        {
            var parameters = new Dictionary<String, String>();
            try
            {
                var lines = memoParameters.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    Dictionary<string, string> dic = Regex.Matches(line, @"(?<key>.*)=(?<value>.*)")
                                                          .OfType<Match>()
                                                          .ToDictionary(m => m.Groups["key"].Value, m => m.Groups["value"].Value);
                    foreach (var kvp in dic)
                    {
                        parameters.Add(kvp.Key, kvp.Value);
                    }
                }
            }
            catch { }

            return parameters;
        }
    }
}