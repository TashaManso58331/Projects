using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfoPanelDx.WireCard.de_DE
{
    public partial class Agreement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxFormLayout1_E4_CheckedChanged(object sender, EventArgs e)
        {
            ASPxFormLayout1_E5.Enabled = ASPxFormLayout1_E4.Checked;
        }
    }
}