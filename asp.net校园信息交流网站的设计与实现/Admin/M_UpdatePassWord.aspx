<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_UpdatePassWord.aspx.cs" Inherits="WebSystem.Admin.M_UpdatePassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>密码修改</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" /> 
      <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript">
    function CheckIn(){
     var OldPass=document.getElementById("txtOldPass").value;
     var temp=document.getElementById("txtNewPass").value;
     var CheckPass=document.getElementById("txtCheckPass").value;
     if(OldPass.length==0||temp.length==0||CheckPass.length==0){
             alert("原始密码,新密码以及确认密码均不能为空！");
             document.getElementById("txtOldPass").focus();
             return false;
     } else if(temp.length<6){
             alert("新密码密码要求长度少于6个字符，请认真输入密码！");
             document.getElementById("txtNewPass").focus();
             return false;
      }
       else if (temp!=CheckPass){
             alert("两次输入密码不相同，请重新输入！");
             document.getElementById("txtNewPass").focus();
             ocument.getElementById("txtCheckPass").value="";
             return false;
      }
     }
    </script>
  </head>
<body>
    <form id="form1" runat="server">
     <div class="div_All">
    <div class="Body_Title">密码维护</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                        原密码：</td>
                    <td width="650px;">
                        <input id="txtOldPass" type="password"   style="width:200px;" runat="server" maxlength="20"/><span class="WarnMes">*</span>原密码，不能为空！</td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                        新密码：</td>
                    <td>
                        <input id="txtNewPass" type="password"   style="width:200px;" runat="server" maxlength="20"/><span class="WarnMes">*</span>新密码，不能为空，20个字符以内。</td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                        确认密码：</td>
                    <td>
                        <input id="txtCheckPass" type="password"   style="width:200px;" runat="server" maxlength="20"/><span class="WarnMes">*</span>确认新密码，不能为空，确保输入一致！</td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="BtnUpdatePass" runat="server" Text=" 更新密码 " OnClientClick="return CheckIn()" onclick="BtnSave_Click" />
                        </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
