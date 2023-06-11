<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_CusList.aspx.cs" Inherits="WebSystem.Admin.M_CusList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>客户信息列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">客户信息管理 》》客户信息列表</div>
    
    <asp:Repeater ID="RpProduct" runat="server" onitemcommand="RpProduct_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th style="width:5%;">选择</th>
                        <th style="width:10%;">用户名</th>
                        <th style="width:10%;">姓名</th>
                        <th style="width:20%;">身份证</th>
                        <th style="width:20%;">地址</th>
                        <th style="width:10%;">电话</th>
                         <th style="width:15%;">客户类型</th>
                        <th style="width:10%;">操作</th>
                        
                        
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("customerid") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("Customername")%></td>
                <td align="center"><%#Eval("Realname")%></td>
                  <td align="center"><%#Eval("CustomerSfz")%></td>
                    <td align="center"><%#Eval("address")%></td>
                      <td align="center"><%#Eval("telphone")%></td>
                       <td align="center">  <img src ='<%#GetAudTag(Eval ("CusType").ToString ())%>' alt ="<%# DataBinder.Eval(Container.DataItem, "CusType").ToString()== "0" ? "普通客户" : "特殊客户"%>" /><asp:LinkButton ID="BtnYes" runat="server" CommandName ="Yes" CommandArgument ='<%#Eval ("customerid").ToString ()%>'>普通客户</asp:LinkButton>&nbsp;<asp:LinkButton
                        ID="BtnNo" runat="server" CommandName ="No" CommandArgument ='<%#Eval ("customerid").ToString ()%>'>特殊客户</asp:LinkButton></td>
                <td align="center"><a href="M_EditCusInfo.aspx?usersid=<%#Eval("customerid") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("customerid")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
      
    <div class="Body_Search"> 
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="全选" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" 删除选中 " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[首页]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[上一页]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[下一页]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[尾页]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="2"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
