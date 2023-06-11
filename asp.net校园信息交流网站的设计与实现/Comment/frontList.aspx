<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Comment_frontList" %>
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
<title>评论查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#commentListPanel" aria-controls="commentListPanel" role="tab" data-toggle="tab">评论列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加评论</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="commentListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>评论id</td><td>被评日志</td><td>评论内容</td><td>评论用户</td><td>评论时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpComment" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("commentId")%></td>
 											<td><%#GetJournaljournalObj(Eval("journalObj").ToString())%></td>
 											<td><%#Eval("content")%></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td><%#Eval("commentTime")%></td>
 											<td>
 												<a href="frontshow.aspx?commentId=<%#Eval("commentId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="commentEdit('<%#Eval("commentId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="commentDelete('<%#Eval("commentId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

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
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>评论查询</h1>
		</div>
            <div class="form-group">
            	<label for="journalObj_commentId">被评日志：</label>
                <asp:DropDownList ID="journalObj" runat="server"  CssClass="form-control" placeholder="请选择被评日志"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="userObj_commentId">评论用户：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择评论用户"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="commentTime">评论时间:</label>
				<asp:TextBox ID="commentTime" runat="server"  CssClass="form-control" placeholder="请输入评论时间"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="commentEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;评论信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="commentEditForm" id="commentEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="comment_commentId_edit" class="col-md-3 text-right">评论id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="comment_commentId_edit" name="comment.commentId" class="form-control" placeholder="请输入评论id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="comment_journalObj_postId_edit" class="col-md-3 text-right">被评日志:</label>
		  	 <div class="col-md-9">
			    <select id="comment_journalObj_postId_edit" name="comment.journalObj.postId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="comment_content_edit" class="col-md-3 text-right">评论内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="comment_content_edit" name="comment.content" rows="8" class="form-control" placeholder="请输入评论内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="comment_userObj_user_name_edit" class="col-md-3 text-right">评论用户:</label>
		  	 <div class="col-md-9">
			    <select id="comment_userObj_user_name_edit" name="comment.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="comment_commentTime_edit" class="col-md-3 text-right">评论时间:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="comment_commentTime_edit" name="comment.commentTime" class="form-control" placeholder="请输入评论时间">
			 </div>
		  </div>
		</form> 
	    <style>#commentEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxCommentModify();">提交</button>
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
/*弹出修改评论界面并初始化数据*/
function commentEdit(commentId) {
	$.ajax({
		url :  basePath + "Comment/CommentController.aspx?action=getComment&commentId=" + commentId,
		type : "get",
		dataType: "json",
		success : function (comment, response, status) {
			if (comment) {
				$("#comment_commentId_edit").val(comment.commentId);
				$.ajax({
					url: basePath + "Journal/JournalController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(journals,response,status) { 
						$("#comment_journalObj_postId_edit").empty();
						var html="";
		        		$(journals).each(function(i,journal){
		        			html += "<option value='" + journal.postId + "'>" + journal.title + "</option>";
		        		});
		        		$("#comment_journalObj_postId_edit").html(html);
		        		$("#comment_journalObj_postId_edit").val(comment.journalObjPri);
					}
				});
				$("#comment_content_edit").val(comment.content);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#comment_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#comment_userObj_user_name_edit").html(html);
		        		$("#comment_userObj_user_name_edit").val(comment.userObjPri);
					}
				});
				$("#comment_commentTime_edit").val(comment.commentTime);
				$('#commentEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除评论信息*/
function commentDelete(commentId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Comment/CommentController.aspx?action=delete",
			data : {
				commentId : commentId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Comment/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交评论信息表单给服务器端修改*/
function ajaxCommentModify() {
	$.ajax({
		url :  basePath + "Comment/CommentController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#commentEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
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

