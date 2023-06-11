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
    public partial class M_EditCusInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["usersid"] != null)
                {
                    if (Request["eables"] != null)
                    {
                        txtU_Name.Disabled = true;
                        txtU_PassW.Visible = false;
                        txtCheckPass.Visible = false;
                        tdcheckpwd.Visible = false;
                        tdpwd.Visible = false;
                        this.Button1.Visible = false;

                    }
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
                txtRealName.Value = user1.Realname;
                txtSfz.Value = user1.CustomerSfz;
                txtAddress.Value = user1.address;
                txtTel.Value = user1.telphone;
            }
        }

        protected void BtnUserSave_Click(object sender, EventArgs e)
        {
            ENTITY.CusUsers u1 = BLL.bllCusUsers.getSomeUserInfo(int.Parse(Request["usersid"]));
            u1.Customername = txtU_Name.Value.ToString();
            if (Request["eables"] != null)
            {
                u1.customerpwd = u1.customerpwd;
            }
            else
            {
                u1.customerpwd = Common.EncryptString.encryptMD5(txtU_PassW.Value.Trim()).ToUpper();
            }
            u1.Realname = txtRealName.Value.ToString();
            u1.CustomerSfz = txtSfz.Value.ToString();
            u1.address = txtAddress.Value.ToString();
            u1.telphone = txtTel.Value.ToString();
            u1.IsCusAdmin = 1;
            u1.CusType = 0;

            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "usersid")))
            {
                u1.customerid = int.Parse(Request["usersid"]);
                if (BLL.bllCusUsers.EditUsersInfo(u1))
                {
                    if (Request["eables"] != null)
                    {
                        Common.ShowMessage.Show(Page, "Suess", "信息修改成功..");            
                    }
                    else
                    {
                        Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditCusInfo.aspx?usersid=" + int.Parse(Request["usersid"]) + "\"} else  {location.href=\"M_CusList.aspx\"} ");
                    }
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_CusList.aspx");
        }
    }
}
