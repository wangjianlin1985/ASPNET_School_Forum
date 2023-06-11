<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_AddUsersInfo.aspx.cs" Inherits="WebSystem.Admin.M_AddUsersInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript">
          function CheckIn() {
                var names = document.getElementById("txtU_Name").value;
                var pass = document.getElementById("txtU_PassW").value;
               
              
                if (names == "") {
                    alert("请输入用户姓名...");
                    document.getElementById("txtU_Name").focus();
                    return false;
                }
               
                else if (pass.length<6) {
                    alert("请正确输入用户密码，请确保密码最短为6位");
                    document.getElementById("txtU_PassW").focus();
                    return false;
                }
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">系统信息管理 》》编辑管理员</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    管理员名：</td>
                    <td width="650px;">
                         <input id="txtU_Name" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入管理员名！</td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                        密码：</td>
                    <td>
                       <input id="txtU_PassW" type="password"   style="width:450px;" runat="server" 
                            maxlength="20" /><span class="WarnMes">*</span>该管理员的登录密码！</td>
                </tr>
                
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnUserSave" runat="server" Text=" 保存信息 "  
                            OnClientClick="return CheckIn()" onclick="BtnUserSave_Click"  />
                        <input id="BtnUserEdit" type="button" value=" 返回 "   onclick='javascript:location.href="M_UsersList.aspx"'   /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
