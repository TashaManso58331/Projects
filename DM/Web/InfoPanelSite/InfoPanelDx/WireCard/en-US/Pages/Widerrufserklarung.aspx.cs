using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfoPanelDx.WireCard.en_US.Pages
{
    public partial class Widerrufserklarung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ViewState["ReferringURL"] = Request.ServerVariables["HTTP_REFERER"];
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            if (ViewState["ReferringURL"] != null)
                Response.Redirect(ViewState["ReferringURL"].ToString());
        }
    }
}