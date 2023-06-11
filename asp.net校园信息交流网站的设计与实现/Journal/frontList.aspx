<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Journal_frontList" %>
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
<title>帖子日志查询</title>
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
			    	<li role="presentation" class="active"><a href="#journalListPanel" aria-controls="journalListPanel" role="tab" data-toggle="tab">帖子日志列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加帖子日志</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="journalListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>日志id</td><td>日志分类</td><td>标题</td><td>发布用户</td><td>发布时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpJournal" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("postId")%></td>
 											<td><%#GetJournalClassjournalClassObj(Eval("journalClassObj").ToString())%></td>
 											<td><%#Eval("title")%></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td><%#Eval("addTime")%></td>
 											<td>
 												<a href="frontshow.aspx?postId=<%#Eval("postId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="journalEdit('<%#Eval("postId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="journalDelete('<%#Eval("postId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>帖子日志查询</h1>
		</div>
            <div class="form-group">
            	<label for="journalClassObj_postId">日志分类：</label>
                <asp:DropDownList ID="journalClassObj" runat="server"  CssClass="form-control" placeholder="请选择日志分类"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="title">标题:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入标题"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="userObj_postId">发布用户：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择发布用户"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="journalEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;帖子日志信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="journalEditForm" id="journalEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="journal_postId_edit" class="col-md-3 text-right">日志id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="journal_postId_edit" name="journal.postId" class="form-control" placeholder="请输入日志id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="journal_journalClassObj_journalClassId_edit" class="col-md-3 text-right">日志分类:</label>
		  	 <div class="col-md-9">
			    <select id="journal_journalClassObj_journalClassId_edit" name="journal.journalClassObj.journalClassId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="journal_title_edit" class="col-md-3 text-right">标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="journal_title_edit" name="journal.title" class="form-control" placeholder="请输入标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="journal_content_edit" class="col-md-3 text-right">日志内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="journal_content_edit" name="journal.content" rows="8" class="form-control" placeholder="请输入日志内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="journal_userObj_user_name_edit" class="col-md-3 text-right">发布用户:</label>
		  	 <div class="col-md-9">
			    <select id="journal_userObj_user_name_edit" name="journal.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="journal_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date journal_addTime_edit col-md-12" data-link-field="journal_addTime_edit">
                    <input class="form-control" id="journal_addTime_edit" name="journal.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#journalEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxJournalModify();">提交</button>
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
/*弹出修改帖子日志界面并初始化数据*/
function journalEdit(postId) {
	$.ajax({
		url :  basePath + "Journal/JournalController.aspx?action=getJournal&postId=" + postId,
		type : "get",
		dataType: "json",
		success : function (journal, response, status) {
			if (journal) {
				$("#journal_postId_edit").val(journal.postId);
				$.ajax({
					url: basePath + "JournalClass/JournalClassController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(journalClasss,response,status) { 
						$("#journal_journalClassObj_journalClassId_edit").empty();
						var html="";
		        		$(journalClasss).each(function(i,journalClass){
		        			html += "<option value='" + journalClass.journalClassId + "'>" + journalClass.journalClassName + "</option>";
		        		});
		        		$("#journal_journalClassObj_journalClassId_edit").html(html);
		        		$("#journal_journalClassObj_journalClassId_edit").val(journal.journalClassObjPri);
					}
				});
				$("#journal_title_edit").val(journal.title);
				$("#journal_content_edit").val(journal.content);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#journal_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#journal_userObj_user_name_edit").html(html);
		        		$("#journal_userObj_user_name_edit").val(journal.userObjPri);
					}
				});
				$("#journal_addTime_edit").val(journal.addTime);
				$('#journalEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除帖子日志信息*/
function journalDelete(postId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Journal/JournalController.aspx?action=delete",
			data : {
				postId : postId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Journal/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交帖子日志信息表单给服务器端修改*/
function ajaxJournalModify() {
	$.ajax({
		url :  basePath + "Journal/JournalController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#journalEditForm")[0]),
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

    /*发布时间组件*/
    $('.journal_addTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

