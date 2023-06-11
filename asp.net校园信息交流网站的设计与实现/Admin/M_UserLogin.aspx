<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_UserLogin.aspx.cs" Inherits="WebSystem.Admin.M_UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>信息管理系统</title>
        <script type="text/javascript">
            if (top.location != self.location)
                top.location = self.location;

            function CheckIn() {
                var names = document.getElementById("txtU_Name").value;
                var pass = document.getElementById("txtU_Pass").value;
                var check = document.getElementById("txtU_Check").value;
                if (names == "") {
                    alert("请输入用户名...");
                    document.getElementById("txtU_Name").focus();
                    return false;
                }
                else if (pass == "") {
                    alert("请输入用户密码...");
                    document.getElementById("txtU_Pass").focus();
                    return false;
                }
                else if (check == "") {
                    alert("请输入验证码...");
                    document.getElementById("txtU_Check").focus();
                    return false;
                }
            }
    </script>
    <style type="text/css">
        body {font:12px Helvetica, Arial, sans-serif;  margin:100px auto; padding:0; background-color:#016BA9;}
        .login1{background-image: url(Images/login_1.jpg); width:960px; height:94px; margin:0 auto;}
        .login2{background-image: url(Images/login_2.jpg); width:960px; height:49px; margin:0 auto; }
        .login3{background-image: url(Images/login_3.jpg); width:960px; height:125px; margin:0 auto;}
        .login4{background-image: url(Images/login_4.jpg); width:960px; height:91px; margin:0 auto;}
        .loginTXT{border: 1px solid #800000; width:150px; background-color:#866961; color:#fff; height:13.5px;}
    </style>
</head>
<body>
     <form id="form1" runat="server" defaultfocus="txtU_Name" defaultbutton="BtnLogin">
    <div class="login1"></div>
    <div class="login2"></div>
    <div class="login3">
           <table cellpadding="0" cellspacing="1" border="0" style="margin-left:320px; width:300px;">
    <tr>
        <td>用户名：</td>
        <td><input id="txtU_Name" type="text" runat="server" class="loginTXT"   maxlength="20"/></td>
    </tr>
    <tr> 
        <td>  密码：</td>
        <td><input id="txtU_Pass" type="password" runat="server" class="loginTXT" maxlength="20"/></td>
    </tr>
    
    <tr>
        <td>验证码：</td>
        <td><input id="txtU_Check" type="text" runat="server" class="loginTXT" style="width:85px;" maxlength="5"/>&nbsp;<img src="M_VateImage.aspx" alt="" style="vertical-align:middle;" onclick="this.src=this.src+'?Math.random()';"/></td>
    </tr>
     <tr> 
        <td>  </td>
        <td>
            <asp:RadioButtonList ID="rblcustype" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">管理员</asp:ListItem>
            <asp:ListItem Value="1">老师</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td colspan="2"><hr /></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="BtnLogin" runat="server" Text="登录"  
                OnClientClicsk="return CheckIn()" onclick="BtnLogin_Click" />
            &nbsp;<input id="BtnHome" style="display:none;" type="button" value="注册" onclick='location.href="../RegUsers.aspx"' /></td>
    </tr>
   </table>
    </div>
    <div class="login4"></div>
    </form>
</body>
</html>
