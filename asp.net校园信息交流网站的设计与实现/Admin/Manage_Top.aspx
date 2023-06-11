<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_Top.aspx.cs" Inherits="WebSystem.Admin.Manage_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Base.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TopBack">
        <div class="TopMes">欢迎你：<font color=red>[<%=uName%>]</font>&nbsp;&nbsp;
        <asp:LinkButton ID="LBQuit" runat="server" Font-Bold="True" ForeColor="White" 
            onclick="LBQuit_Click" OnClientClick='return confirm("你确定退出本系统吗？") '>[退出管理]</asp:LinkButton>
        </div>
        <img src="Images/TopLogo.jpg" alt="信息管理系统..." style="float:right;"/>
    </div>
    </form>
</body>
</html>