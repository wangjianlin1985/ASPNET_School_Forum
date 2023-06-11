using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.force.json;

public partial class frontLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int success = 0;
        string message = "";
        string userName = Request["userName"];
        string password = Request["password"];
       
        ENTITY.UserInfo userInfo =  BLL.bllUserInfo.getSomeUserInfo(userName);
        if (userInfo == null  || userInfo.password != password) {
            message = "用户名或密码错误!";
            writeResult(success, message);
            return ;
        }

        success = 1;
        Session["user_name"] = userName;
        writeResult(success, message);
    }


    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }
}