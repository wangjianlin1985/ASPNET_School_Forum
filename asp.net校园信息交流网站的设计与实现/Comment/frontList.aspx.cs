using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Comment_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindjournalObj();
            BinduserObj();
            string sqlstr = " where 1=1 ";
            if (Request["journalObj"] != null && Request["journalObj"].ToString() != "0")
            {
                    sqlstr += "  and journalObj=" + Request["journalObj"].ToString();
                    journalObj.SelectedValue = Request["journalObj"].ToString();
            }
            if (Request["userObj"] != null && Request["userObj"].ToString() != "")
            {
                sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                userObj.SelectedValue = Request["userObj"].ToString();
            }
            if (Request["commentTime"] != null && Request["commentTime"].ToString() != "")
            {
                sqlstr += "  and commentTime like '%" + Request["commentTime"].ToString() + "%'";
                commentTime.Text = Request["commentTime"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindjournalObj()
    {
        ListItem li = new ListItem("不限制", "0");
        journalObj.Items.Add(li);
        DataSet journalObjDs = BLL.bllJournal.getAllJournal();
        for (int i = 0; i < journalObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = journalObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["title"].ToString(),dr["postId"].ToString());
            journalObj.Items.Add(li);
        }
        journalObj.SelectedValue = "0";
    }

    private void BinduserObj()
    {
        ListItem li = new ListItem("不限制", "");
        userObj.Items.Add(li);
        DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
        for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = userObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["name"].ToString(),dr["user_name"].ToString());
            userObj.Items.Add(li);
        }
        userObj.SelectedValue = "";
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
        DataTable dsLog = BLL.bllComment.GetComment(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpComment.DataSource = dsLog;
        RpComment.DataBind();
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
        public string GetJournaljournalObj(string journalObj)
        {
            return BLL.bllJournal.getSomeJournal(int.Parse(journalObj)).title;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?journalObj=" + journalObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&commentTime=" + commentTime.Text.Trim());
        }

}
