<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="WebLink_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>友情链接查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-12 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">友情链接信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加友情链接</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpWebLink" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="<%#Eval("webAddress") %>" target="_blank"><img class="img-responsive" src="../<%#Eval("webLogo")%>" /></a>
			     <div class="showFields"> 
			     	<div class="field">
	            		网站名称: <%#Eval("webName")%>
			     	</div>
			     	 
			        <a class="btn btn-primary top5" href="frontShow.aspx?linkId=<%#Eval("linkId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="webLinkEdit('<%#Eval("linkId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="webLinkDelete('<%#Eval("linkId")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

  </form>
</div>
<div id="webLinkEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;友情链接信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="webLinkEditForm" id="webLinkEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="webLink_linkId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="webLink_linkId_edit" name="webLink.linkId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="webLink_webName_edit" class="col-md-3 text-right">网站名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="webLink_webName_edit" name="webLink.webName" class="form-control" placeholder="请输入网站名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="webLink_webLogo_edit" class="col-md-3 text-right">网站Logo:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="webLink_webLogoImg" border="0px"/><br/>
			    <input type="hidden" id="webLink_webLogo" name="webLink.webLogo"/>
			    <input id="webLogoFile" name="webLogoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="webLink_webAddress_edit" class="col-md-3 text-right">网站地址:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="webLink_webAddress_edit" name="webLink.webAddress" class="form-control" placeholder="请输入网站地址">
			 </div>
		  </div>
		</form> 
	    <style>#webLinkEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxWebLinkModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改友情链接界面并初始化数据*/
function webLinkEdit(linkId) {
	$.ajax({
		url :  basePath + "WebLink/WebLinkController.aspx?action=getWebLink&linkId=" + linkId,
		type : "get",
		dataType: "json",
		success : function (webLink, response, status) {
			if (webLink) {
				$("#webLink_linkId_edit").val(webLink.linkId);
				$("#webLink_webName_edit").val(webLink.webName);
				$("#webLink_webLogo").val(webLink.webLogo);
				$("#webLink_webLogoImg").attr("src", basePath +　webLink.webLogo);
				$("#webLink_webAddress_edit").val(webLink.webAddress);
				$('#webLinkEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除友情链接信息*/
function webLinkDelete(linkId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "WebLink/WebLinkController.aspx?action=delete",
			data : {
				linkId : linkId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "WebLink/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交友情链接信息表单给服务器端修改*/
function ajaxWebLinkModify() {
	$.ajax({
		url :  basePath + "WebLink/WebLinkController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#webLinkEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                location.href= basePath + "WebLink/frontList.aspx";
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

})
</script>
</body>
</html>

