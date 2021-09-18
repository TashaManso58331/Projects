using System;
using InfoPanelModels.Models;

namespace InfoPanelDx
{
    public class Global_asax : System.Web.HttpApplication {
            void Application_Start(object sender, EventArgs e) {
                DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(Application_Error);


            FakeManger.Instance.IsFake = DefineFakeFromAppSettings();
            }

        private bool DefineFakeFromAppSettings()
        {
#if DEBUG 
            return false;
#endif

            try
            {

                var fakeStr = System.Web.Configuration.WebConfigurationManager.AppSettings["Fake"];
                System.Diagnostics.Debug.WriteLine($"fake = {fakeStr} in appSettings");
                fakeStr = string.Compare(fakeStr, "__Fake__") == 0 ? true.ToString() : fakeStr;
                return Convert.ToBoolean(fakeStr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to define fake from appSettings due to {ex}");
                return true;
            }
        }

        void Application_End(object sender, EventArgs e) {
                // Code that runs on application shutdown
            }

            void Application_Error(object sender, EventArgs e) {
                // Code that runs when an unhandled error occurs
            }

            void Session_Start(object sender, EventArgs e) {
                // Code that runs when a new session is started
            }

            void Session_End(object sender, EventArgs e) {
                // Code that runs when a session ends. 
                // Note: The Session_End event is raised only when the sessionstate mode
                // is set to InProc in the Web.config file. If session mode is set to StateServer 
                // or SQLServer, the event is not raised.
            }
        }
    }