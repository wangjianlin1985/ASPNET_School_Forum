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

namespace WebSystem
{
    public partial class RegUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnUserSave_Click(object sender, EventArgs e)
        {
            ENTITY.CusUsers u1 = new ENTITY.CusUsers();
            u1.Customername = txtU_Name.Value.ToString();
            u1.customerpwd = Common.EncryptString.encryptMD5(txtU_PassW.Value.Trim()).ToUpper();
            u1.Realname = txtRealName.Value.ToString();
            u1.CustomerSfz = txtSfz.Value.ToString();
            u1.address = txtAddress.Value.ToString();
            u1.telphone = txtTel.Value.ToString();
            u1.IsCusAdmin = 1;
            u1.CusType = 0;


            if (!BLL.bllCusUsers.Vld_UserName(ref u1))
            {
                if (BLL.bllCusUsers.AddUsersInfo(u1))
                {
                    Common.ShowMessage.Show(Page, "Suess", "用户注册成功..");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "用户注册失败..");
                }
            }
            else
            {
                Common.ShowMessage.Show(Page, "error", "此用户名已经被占用..");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin/M_UserLogin.aspx");
        }
    }
}
