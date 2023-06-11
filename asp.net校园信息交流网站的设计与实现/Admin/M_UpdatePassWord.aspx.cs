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
    public partial class M_UpdatePassWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (Session["Customername"] != null)
            {
                List<ENTITY.CusUsers> listfor = BLL.bllCusUsers.getUserId(Session["Customername"].ToString());
                int user_id = listfor[0].customerid;

                if (BLL.bllCusUsers.ChangeUserPass(txtOldPass.Value.ToString(), txtCheckPass.Value.ToString(), user_id))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"修改密码成功，是否重新登录？\")) {location.href=\"M_UserLogin.aspx\"} else  {location.href=\"Main.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "提示", "密码修改失败,请确保原始密码的正确性", "M_UpdatePassWord.aspx");
                }
            }        
        }
    }
}
