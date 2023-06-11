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

namespace chengxusheji.Admin
{
    public partial class PhotoInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindphotoClassObj();
                BinduserObj();
                string sqlstr = " where 1=1 ";
                if (Request["photoClassObj"] != null && Request["photoClassObj"].ToString() != "0")
                {
                    sqlstr += "  and photoClassObj=" + Request["photoClassObj"].ToString();
                    photoClassObj.SelectedValue = Request["photoClassObj"].ToString();
                }
                if (Request["photoName"] != null && Request["photoName"].ToString() != "")
                {
                    sqlstr += "  and photoName like '%" + Request["photoName"].ToString() + "%'";
                    photoName.Text = Request["photoName"].ToString();
                }
                if (Request["userObj"] != null && Request["userObj"].ToString() != "")
                {
                    sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                    userObj.SelectedValue = Request["userObj"].ToString();
                }
                if (Request["addTime"] != null && Request["addTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                    addTime.Text = Request["addTime"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindphotoClassObj()
        {
            ListItem li = new ListItem("不限制", "0");
            photoClassObj.Items.Add(li);
            DataSet photoClassObjDs = BLL.bllPhotoClass.getAllPhotoClass();
            for (int i = 0; i < photoClassObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = photoClassObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["photoClassName"].ToString(), dr["photoClassName"].ToString());
                photoClassObj.Items.Add(li);
            }
            photoClassObj.SelectedValue = "0";
        }

        private void BinduserObj()
        {
            ListItem li = new ListItem("不限制", "");
            userObj.Items.Add(li);
            DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
            for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = userObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                userObj.Items.Add(li);
            }
            userObj.SelectedValue = "";
        }

        protected void BtnPhotoInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhotoInfoEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllPhotoInfo.DelPhotoInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "PhotoInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
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
            DataTable dsLog = BLL.bllPhotoInfo.GetPhotoInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpPhotoInfo.DataSource = dsLog;
            RpPhotoInfo.DataBind();
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
        protected void RpPhotoInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllPhotoInfo.DelPhotoInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "PhotoInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "PhotoInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "PhotoInfoList.aspx");
                }
            }
        }
        public string GetPhotoClassphotoClassObj(string photoClassObj)
        {
            return BLL.bllPhotoClass.getSomePhotoClass(int.Parse(photoClassObj)).photoClassName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhotoInfoList.aspx?photoClassObj=" + photoClassObj.SelectedValue.Trim()+ "&&photoName=" + photoName.Text.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet photoInfoDataSet = BLL.bllPhotoInfo.GetPhotoInfo(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>照片记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>照片id</th>");
            sb.Append("<th>照片分类</th>");
            sb.Append("<th>照片名称</th>");
            sb.Append("<th>照片文件</th>");
            sb.Append("<th>发布用户</th>");
            sb.Append("<th>发布时间</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < photoInfoDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = photoInfoDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["photoId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllPhotoClass.getSomePhotoClass(Convert.ToInt32(dr["photoClassObj"])).photoClassName + "</td>");
                sb.Append("<td>" + dr["photoName"].ToString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["photoImage"].ToString() + "'/></span></td>");
                sb.Append("<td>" + BLL.bllUserInfo.getSomeUserInfo(dr["userObj"].ToString()).name + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["addTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "照片记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
