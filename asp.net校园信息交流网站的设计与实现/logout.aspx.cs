﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("user_name");	//移除保存在session中的username属性 
	    Session.Abandon();
	    Response.Write("<script>top.location='index.aspx';</script>");
    }
}