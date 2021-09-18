using System;
using System.Linq;
using DevExpress.Web;
using InfoPanelModels.Models;

namespace InfoPanelDx {
    public partial class Root : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            MainSplitter.GetPaneByName("HeaderPane").Size = ASPxWebControl.GlobalTheme == "Moderno" ? 101 : 87;
            MainSplitter.GetPaneByName("HeaderPane").MinSize = ASPxWebControl.GlobalTheme == "Moderno" ? 101 : 87;

            var miRobots = MenuTop.Items.FirstOrDefault(c => c.Name == "Robots");
            if (miRobots != null)
            {
                miRobots.Visible = FakeManger.Instance.IsFake;
            }
        }
    }
}