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
using System.Collections.Generic;

namespace WebSystem.Admin
{
    public partial class Cus_Left : System.Web.UI.Page
    {
        public int user_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Session["Customername"] != null)
                {
                    List<ENTITY.CusUsers> listfor = BLL.bllCusUsers.getUserId(Session["Customername"].ToString());
                    user_id = listfor[0].customerid;
                }
            }
        }
    }
}
