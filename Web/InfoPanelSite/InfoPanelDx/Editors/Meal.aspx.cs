using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI.WebControls;

namespace InfoPanelDx.Editors
{
    public partial class Meal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Alcohol.DataSource = new List<String> { String.Empty, "No_Alcohol_Served", "Wine-Beer", "Full_Bar" };
                Alcohol.DataBind();

                SmokingArea.DataSource = new List<String> { String.Empty, "none", "only at bar", "permitted", "section", "not permitted" };
                SmokingArea.DataBind();

                DressCode.DataSource = new List<String> { String.Empty, "informal", "casual", "formal" };
                DressCode.DataBind();

                Accessibility.DataSource = new List<String> { String.Empty, "no_accessibility", "completely", "partially" };
                Accessibility.DataBind();

                Price.DataSource = new List<String> { String.Empty, "medium", "low", "high" };
                Price.DataBind();

                Rambience.DataSource = new List<String> { String.Empty, "familiar", "quiet" };
                Rambience.DataBind();

                Area.DataSource = new List<String> { String.Empty, "closed", "open" };
                Area.DataBind();

                OtherServices.DataSource = new List<String> { String.Empty, "none", "Internet", "variety" };
                OtherServices.DataBind();
            }
        }

        public async Task LoadData()
        {
            try
            {
                await LoadFromAML();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task LoadFromAML()
        {
            // This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
            // Instructions for doing this in Visual Studio:
            // Tools -> Nuget Package Manager -> Package Manager Console
            // Install-Package Microsoft.AspNet.WebApi.Client
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "alcohol", Alcohol.SelectedValue ?? String.Empty
                                            },
                                            {
                                                "smoking_area", SmokingArea.SelectedValue ?? String.Empty
                                            },
                                            {
                                                "dress_code", DressCode.SelectedValue ?? String.Empty
                                            },
                                            {
                                                "accessibility", Accessibility.SelectedValue ?? String.Empty
                                            },
                                            {
                                                "price", Price.SelectedValue ?? String.Empty
                                            },
                                            {
                                                "Rambience", Rambience.SelectedValue ?? String.Empty
                                            },
                                            {
                                                "area", Area.SelectedValue ?? String.Empty
                                            },
                                            {
                                                "other_services", OtherServices.SelectedValue ?? String.Empty
                                            },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                const string apiKey = "KMP9DxP0r+V31c+BQWq3JHyaNrCaTHlSUfadXysHpCyilllOQM678BOo+4dX8PebI73rFw3EfDuKipCyyFrn/A=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/e5170f055d524e259a8d89e00aa0460d/services/1a40f20fede547f0887f5271a3d4e3f5/execute?api-version=2.0&format=swagger");

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)

                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    ResultText.Text = result;
                    Console.WriteLine("Result: {0}", result);
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Task.Run(async () => await LoadData()).Wait(TimeSpan.FromMinutes(10));
        }
    }
}
