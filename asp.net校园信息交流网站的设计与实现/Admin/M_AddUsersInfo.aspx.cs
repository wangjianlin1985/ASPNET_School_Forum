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
    public partial class M_AddUsersInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["usersid"] != null)
                {
                    LoadData();
                }
            }
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "usersid")))
            {
                ENTITY.CusUsers user1 = BLL.bllCusUsers.getSomeUserInfo(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "usersid")));
                txtU_Name.Value = user1.Customername;
            }
        }

        protected void BtnUserSave_Click(object sender, EventArgs e)
        {
            ENTITY.CusUsers u1 = new ENTITY.CusUsers();
            u1.Customername = txtU_Name.Value.ToString();
            u1.customerpwd = Common.EncryptString.encryptMD5(txtU_PassW.Value.Trim()).ToUpper();
            u1.Realname = "";
            u1.CustomerSfz = "";
            u1.address = "";
            u1.telphone = "";
            u1.IsCusAdmin = 0;
            u1.CusType = 0;

            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "usersid")))
            {
                u1.customerid = int.Parse(Request["usersid"]);
                if (BLL.bllCusUsers.EditUsersInfo(u1))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_AddUsersInfo.aspx?usersid=" + int.Parse(Request["usersid"]) + "\"} else  {location.href=\"M_UsersList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }

            }
            else
            {
                if (!BLL.bllCusUsers.Vld_UserName(ref u1))
                {
                    if (BLL.bllCusUsers.AddUsersInfo(u1))
                    {
                        Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_AddUsersInfo.aspx\"} else  {location.href=\"M_UsersList.aspx\"} ");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                    }
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "此管理员名已经被占用..");
                }
            }
           
        }
    }
}
