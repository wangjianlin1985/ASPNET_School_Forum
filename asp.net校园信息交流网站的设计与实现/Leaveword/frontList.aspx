<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Leaveword_frontList" %>
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
<title>留言查询</title>
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
			    	<li role="presentation" class="active"><a href="#leavewordListPanel" aria-controls="leavewordListPanel" role="tab" data-toggle="tab">留言列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加留言</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="leavewordListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>留言id</td><td>留言标题</td><td>提问文件</td><td>留言人</td><td>留言时间</td><td>老师回复</td><td>回复时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpLeaveword" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("leaveWordId")%></td>
 											<td><%#Eval("leaveTitle")%></td>
 											<td><%#Eval("questionFile").ToString() == ""?"暂无文件":"<a href='../" + Eval("questionFile").ToString() + "' target='_blank'>" + Eval("questionFile").ToString() +  "</a>" %></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td><%#Eval("leaveTime")%></td>
 											<td><%#Eval("replyContent")%></td>
 											<td><%#Eval("replyTime")%></td>
 											<td>
 												<a href="frontshow.aspx?leaveWordId=<%#Eval("leaveWordId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="leavewordEdit('<%#Eval("leaveWordId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="leavewordDelete('<%#Eval("leaveWordId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>留言查询</h1>
		</div>
			<div class="form-group">
				<label for="leaveTitle">留言标题:</label>
				<asp:TextBox ID="leaveTitle" runat="server"  CssClass="form-control" placeholder="请输入留言标题"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="userObj_leaveWordId">留言人：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择留言人"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="leaveTime">留言时间:</label>
				<asp:TextBox ID="leaveTime"  runat="server" CssClass="form-control" placeholder="请选择留言时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="leavewordEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;留言信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="leavewordEditForm" id="leavewordEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="leaveword_leaveWordId_edit" class="col-md-3 text-right">留言id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="leaveword_leaveWordId_edit" name="leaveword.leaveWordId" class="form-control" placeholder="请输入留言id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="leaveword_leaveTitle_edit" class="col-md-3 text-right">留言标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="leaveword_leaveTitle_edit" name="leaveword.leaveTitle" class="form-control" placeholder="请输入留言标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="leaveword_leaveContent_edit" class="col-md-3 text-right">留言内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="leaveword_leaveContent_edit" name="leaveword.leaveContent" rows="8" class="form-control" placeholder="请输入留言内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="leaveword_questionFile_edit" class="col-md-3 text-right">提问文件:</label>
		  	 <div class="col-md-9">
			    <a id="leaveword_questionFileA" target="_blank"></a><br/>
			    <input type="hidden" id="leaveword_questionFile" name="leaveword.questionFile"/>
			    <input id="questionFileFile" name="questionFileFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="leaveword_userObj_user_name_edit" class="col-md-3 text-right">留言人:</label>
		  	 <div class="col-md-9">
			    <select id="leaveword_userObj_user_name_edit" name="leaveword.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="leaveword_leaveTime_edit" class="col-md-3 text-right">留言时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date leaveword_leaveTime_edit col-md-12" data-link-field="leaveword_leaveTime_edit">
                    <input class="form-control" id="leaveword_leaveTime_edit" name="leaveword.leaveTime" size="16" type="text" value="" placeholder="请选择留言时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="leaveword_replyContent_edit" class="col-md-3 text-right">老师回复:</label>
		  	 <div class="col-md-9">
			    <textarea id="leaveword_replyContent_edit" name="leaveword.replyContent" rows="8" class="form-control" placeholder="请输入老师回复"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="leaveword_replyTime_edit" class="col-md-3 text-right">回复时间:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="leaveword_replyTime_edit" name="leaveword.replyTime" class="form-control" placeholder="请输入回复时间">
			 </div>
		  </div>
		</form> 
	    <style>#leavewordEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxLeavewordModify();">提交</button>
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
/*弹出修改留言界面并初始化数据*/
function leavewordEdit(leaveWordId) {
	$.ajax({
		url :  basePath + "Leaveword/LeavewordController.aspx?action=getLeaveword&leaveWordId=" + leaveWordId,
		type : "get",
		dataType: "json",
		success : function (leaveword, response, status) {
			if (leaveword) {
				$("#leaveword_leaveWordId_edit").val(leaveword.leaveWordId);
				$("#leaveword_leaveTitle_edit").val(leaveword.leaveTitle);
				$("#leaveword_leaveContent_edit").val(leaveword.leaveContent);
				$("#leaveword_questionFile").val(leaveword.questionFile);
				$("#leaveword_questionFileA").text(leaveword.questionFile);
				$("#leaveword_questionFileA").attr("href", basePath +　leaveword.questionFile);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#leaveword_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#leaveword_userObj_user_name_edit").html(html);
		        		$("#leaveword_userObj_user_name_edit").val(leaveword.userObjPri);
					}
				});
				$("#leaveword_leaveTime_edit").val(leaveword.leaveTime);
				$("#leaveword_replyContent_edit").val(leaveword.replyContent);
				$("#leaveword_replyTime_edit").val(leaveword.replyTime);
				$('#leavewordEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除留言信息*/
function leavewordDelete(leaveWordId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Leaveword/LeavewordController.aspx?action=delete",
			data : {
				leaveWordId : leaveWordId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Leaveword/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交留言信息表单给服务器端修改*/
function ajaxLeavewordModify() {
	$.ajax({
		url :  basePath + "Leaveword/LeavewordController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#leavewordEditForm")[0]),
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

    /*留言时间组件*/
    $('.leaveword_leaveTime_edit').datetimepicker({
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

