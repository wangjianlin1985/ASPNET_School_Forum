<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cus_Left.aspx.cs" Inherits="WebSystem.Admin.Cus_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
   
         <div class="Menu"> <a href="M_EditCusInfo.aspx?usersid=<%=user_id %>&&eables=1" target="main"><img src="Images/LookMes.gif" alt=""/>&nbsp;修改信息</a></div>
         
          <img src="images/menu_topline.gif" alt="" />
                <div class="Menu"> <a href="#" target="main"><img src="Images/LookMes.gif" alt=""/>&nbsp;扩展功能</a></div>
       
          <img src="images/menu_topline.gif" alt="" />
               <div class="Menu"> <a href="#" target="main"><img src="Images/LookMes.gif" alt=""/>&nbsp;扩展功能</a></div>
        <img src="images/menu_topline.gif" alt="" />
        
                <div class="Menu"> <a href="#" target="main"><img src="Images/LookMes.gif" alt=""/>&nbsp;扩展功能</a></div>
        <img src="images/menu_topline.gif" alt="" />
         
                 <div class="Menu"> <a href="M_UpdatePassWord.aspx" target="main"><img src="Images/LookMes.gif" alt=""/>&nbsp;密码维护</a></div>
        
    </div>
    </form>
</body>
</html>