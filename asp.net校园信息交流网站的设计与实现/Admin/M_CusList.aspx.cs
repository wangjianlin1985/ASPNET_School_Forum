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
    public partial class M_CusList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                HWhere.Value = " where IsCusAdmin =1";
                BindData("");
            }
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                if (BLL.bllCusUsers.DelUsersInfo(HSelectID.Value.Trim()))
                {
                    Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "M_CusList.aspx");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                }
            }
        }
        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllCusUsers.GetUsersInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpProduct.DataSource = dsLog;
            RpProduct.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();

        }
        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }

        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }

        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }

        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }


        protected void RpProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                if (BLL.bllCusUsers.DelUsersInfo((e.CommandArgument.ToString())))
                {
                    Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "M_CusList.aspx");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "M_CusList.aspx");
                }
            }

            if (e.CommandName == "Yes")
            {
                BLL.bllCusUsers.CheckUserType(int.Parse(e.CommandArgument.ToString()), 0);

                Response.Redirect("M_CusList.aspx");
            }

            if (e.CommandName == "No")
            {
                BLL.bllCusUsers.CheckUserType(int.Parse(e.CommandArgument.ToString()), 1);

                Response.Redirect("M_CusList.aspx");
            }

        }

        public string GetAudTag(string audtag)
        {
            if (audtag.Trim() == "0")
            {
                return "images/yes.gif";
            }
            else
            {
                if (audtag.Trim() == "1")
                {
                    return "images/del.gif";
                }
                else
                {
                    return "images/del.gif";
                }
            }

        }
    }
}
