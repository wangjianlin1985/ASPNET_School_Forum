<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

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
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学生管理</div>
        <div class="MenuNote" style="display:none;" id="UserInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="UserInfoEdit.aspx" target="main">添加学生</a></li>
                <li><a href="UserInfoList.aspx" target="main">学生查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;教师管理</div>
        <div class="MenuNote" style="display:none;" id="TeacherDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="TeacherEdit.aspx" target="main">添加教师</a></li>
                <li><a href="TeacherList.aspx" target="main">教师查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;照片管理</div>
        <div class="MenuNote" style="display:none;" id="PhotoInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                 <li><a href="PhotoClassEdit.aspx" target="main">添加照片分类</a></li>
                <li><a href="PhotoClassList.aspx" target="main">照片分类查询</a></li> 
                <li><a href="PhotoInfoEdit.aspx" target="main">添加照片</a></li>
                <li><a href="PhotoInfoList.aspx" target="main">照片查询</a></li> 
            </ul>
        </div>

       

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;帖子日志管理</div>
        <div class="MenuNote" style="display:none;" id="JournalDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="JournalClassEdit.aspx" target="main">添加日志分类</a></li>
                <li><a href="JournalClassList.aspx" target="main">日志分类查询</a></li>
                <li><a href="JournalEdit.aspx" target="main">添加帖子日志</a></li>
                <li><a href="JournalList.aspx" target="main">帖子日志查询</a></li> 
            </ul>
        </div>

        

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;评论管理</div>
        <div class="MenuNote" style="display:none;" id="CommentDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="CommentEdit.aspx" target="main">添加评论</a></li>
                <li><a href="CommentList.aspx" target="main">评论查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;留言管理</div>
        <div class="MenuNote" style="display:none;" id="LeavewordDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="LeavewordEdit.aspx" target="main">添加留言</a></li>
                <li><a href="LeavewordList.aspx" target="main">留言查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;网站新闻管理</div>
        <div class="MenuNote" style="display:none;" id="NewsDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="NewsEdit.aspx" target="main">添加网站新闻</a></li>
                <li><a href="NewsList.aspx" target="main">网站新闻查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;友情链接管理</div>
        <div class="MenuNote" style="display:none;" id="WebLinkDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="WebLinkEdit.aspx" target="main">添加友情链接</a></li>
                <li><a href="WebLinkList.aspx" target="main">友情链接查询</a></li> 
            </ul>
        </div>

 
    <!--
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div>
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div> -->

        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
