<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegUsers.aspx.cs" Inherits="WebSystem.RegUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>信息管理系统</title>
   <link href="Admin/Style/Manage.css"rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Admin/JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="Admin/JavaScript/Admin.js"></script>
    <script type="text/javascript">
          function CheckIn() {
                var names = document.getElementById("txtU_Name").value;
                var pass = document.getElementById("txtU_PassW").value;
                var CheckPass=document.getElementById("txtCheckPass").value;
              
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
                
                  if(pass.length==0||CheckPass.length==0){
             alert("密码以及确认密码均不能为空！");
             document.getElementById("txtU_PassW").focus();
             return false;
     }
    else if (pass!=CheckPass){
             alert("两次输入密码不相同，请重新输入！");
             document.getElementById("txtCheckPass").focus();
             document.getElementById("txtCheckPass").value="";
             return false;
      }
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">注册客户</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    用户名：</td>
                    <td width="650px;">
                         <input id="txtU_Name" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入用户名！</td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                        密码：</td>
                    <td>
                       <input id="txtU_PassW" type="password"   style="width:200px;" runat="server" 
                            maxlength="20" /><span class="WarnMes">*</span>该用户的登录密码！</td>
                </tr>
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                        确认密码：</td>
                    <td>
                        <input id="txtCheckPass" type="password"   style="width:200px;" runat="server" maxlength="20"/><span class="WarnMes">*</span>确认密码，不能为空，确保输入一致！</td>
                </tr>
                
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    姓名：</td>
                    <td width="650px;">
                         <input id="txtRealName" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    身份证：</td>
                    <td width="650px;">
                         <input id="txtSfz" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    地址：</td>
                    <td width="650px;">
                         <input id="txtAddress" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    联系电话：</td>
                    <td width="650px;">
                         <input id="txtTel" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>
                
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnUserSave" runat="server" Text=" 保存信息 "  
                            OnClientClick="return CheckIn()" onclick="BtnUserSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="返回登录" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
