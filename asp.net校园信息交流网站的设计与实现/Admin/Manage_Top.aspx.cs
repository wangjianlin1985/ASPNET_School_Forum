using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebSystem.Admin
{
    public partial class Manage_Top : System.Web.UI.Page
    {
        public string uName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customername"] != null)
            {
                uName = Session["Customername"].ToString();
            }
        }

        protected void LBQuit_Click(object sender, EventArgs e)
        {
            Common.SetMes.RemoveSession("Customername");
            Common.SetMes.RemoveSession("IsCusAdmin");
            Common.ShowMessage.RefreshPage(Page, "throw", "top", "../index.aspx");
        }
    }
}
