<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="footer" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
%>
<!--footer-->
<footer>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
            	<a href="http://www.baidu.com" target=_blank>© 大神开发网 from 2018</a> | 
				<a href="http://www.baidu.com">本站招聘</a> | 
				<a href="http://www.baidu.com">联系站长</a> | 
				<a href="http://www.baidu.com">意见与建议</a> | 
				<a href="http://www.baidu.com" target=_blank>湘ICP备0703346号</a> | 
				<a href="<%=basePath%>Admin/M_UserLogin.aspx">后台登录</a>
            </div>
        </div>
    </div>
</footer>
<!--footer--> 

 