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
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;

namespace WebSystem.Admin
{
    public partial class M_UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtU_Name.Focus();
                Common.SetMes.RemoveSession("UserID");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (CheckNull())
            {
                string uID = txtU_Name.Value.Trim();
                string pwdMd5 = Common.EncryptString.encryptMD5(txtU_Pass.Value.ToString()).ToUpper();

                int isadmincus = int.Parse(rblcustype.SelectedValue.Trim());
                ENTITY.CusUsers userlogin = new ENTITY.CusUsers(uID, pwdMd5,isadmincus);
                string checkCode = Session["CheckCode"].ToString().ToUpper();
                if (txtU_Check.Value.Trim().ToUpper() != checkCode)
                {

                    Common.ShowMessage.Show(Page, "Error1", "验证密码有误，请重新登录...", "M_UserLogin.aspx");
                }
                else
                {
                    bool success;
                    if (isadmincus == 0) success = BLL.bllCusUsers.ulogin(ref userlogin);
                    else success = BLL.bllTeacher.ulogin(uID, txtU_Pass.Value);
                    Session["Customername"] = uID;
                    Session["IsCusAdmin"] = isadmincus.ToString(); 
                   
                        if (success && (Session["Customername"] != null)&&Session["IsCusAdmin"].ToString() == "0")
                        {
                            Response.Redirect("AdminIndex.aspx");
                        }
                        else if (success && (Session["Customername"] != null) && Session["IsCusAdmin"].ToString() == "1")
                        {
                            Response.Redirect("TeacherIndex.aspx");
                        }
                        else
                        {
                            Common.ShowMessage.Show(Page, "Error1", "帐号和密码输入不匹配，请重新登录..."+pwdMd5, "M_UserLogin.aspx");
                        }
                }
            }
        }

        private bool CheckNull()
        {
            return (!(string.IsNullOrEmpty(txtU_Name.Value.Trim())) && !(string.IsNullOrEmpty(txtU_Pass.Value.Trim())) && !(string.IsNullOrEmpty(txtU_Check.Value.Trim()))) ? true : false;
        }
    }
}
