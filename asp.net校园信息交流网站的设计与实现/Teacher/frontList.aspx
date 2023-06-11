<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Teacher_frontList" %>
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
<title>教师查询</title>
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
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">教师信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加教师</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpTeacher" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?teacherNo=<%#Eval("teacherNo")%>"><img class="img-responsive" src="../<%#Eval("teacherPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		教师编号: <%#Eval("teacherNo")%>
			     	</div>
			     	<div class="field">
	            		姓名: <%#Eval("name")%>
			     	</div>
			     	<div class="field">
	            		性别: <%#Eval("sex")%>
			     	</div>
			     	<div class="field">
	            		出生日期: <%#Eval("bornDate")%>
			     	</div>
			     	<div class="field">
	            		联系电话: <%#Eval("telephone")%>
			     	</div>
			     	<div class="field">
	            		邮箱: <%#Eval("email")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?teacherNo=<%#Eval("teacherNo")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="teacherEdit('<%#Eval("teacherNo")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="teacherDelete('<%#Eval("teacherNo")%>');" style="display:none;">删除</a>
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

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>教师查询</h1>
		</div>
			<div class="form-group">
				<label for="teacherNo">教师编号:</label>
				<asp:TextBox ID="teacherNo" runat="server"  CssClass="form-control" placeholder="请输入教师编号"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="name">姓名:</label>
				<asp:TextBox ID="name" runat="server"  CssClass="form-control" placeholder="请输入姓名"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="bornDate">出生日期:</label>
				<asp:TextBox ID="bornDate"  runat="server" CssClass="form-control" placeholder="请选择出生日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="telephone">联系电话:</label>
				<asp:TextBox ID="telephone" runat="server"  CssClass="form-control" placeholder="请输入联系电话"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="teacherEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;教师信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="teacherEditForm" id="teacherEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="teacher_teacherNo_edit" class="col-md-3 text-right">教师编号:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="teacher_teacherNo_edit" name="teacher.teacherNo" class="form-control" placeholder="请输入教师编号" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="teacher_password_edit" class="col-md-3 text-right">登录密码:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teacher_password_edit" name="teacher.password" class="form-control" placeholder="请输入登录密码">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teacher_name_edit" class="col-md-3 text-right">姓名:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teacher_name_edit" name="teacher.name" class="form-control" placeholder="请输入姓名">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teacher_sex_edit" class="col-md-3 text-right">性别:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teacher_sex_edit" name="teacher.sex" class="form-control" placeholder="请输入性别">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teacher_bornDate_edit" class="col-md-3 text-right">出生日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date teacher_bornDate_edit col-md-12" data-link-field="teacher_bornDate_edit" data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="teacher_bornDate_edit" name="teacher.bornDate" size="16" type="text" value="" placeholder="请选择出生日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teacher_teacherPhoto_edit" class="col-md-3 text-right">教师照片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="teacher_teacherPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="teacher_teacherPhoto" name="teacher.teacherPhoto"/>
			    <input id="teacherPhotoFile" name="teacherPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teacher_telephone_edit" class="col-md-3 text-right">联系电话:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teacher_telephone_edit" name="teacher.telephone" class="form-control" placeholder="请输入联系电话">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teacher_email_edit" class="col-md-3 text-right">邮箱:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teacher_email_edit" name="teacher.email" class="form-control" placeholder="请输入邮箱">
			 </div>
		  </div>
		</form> 
	    <style>#teacherEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxTeacherModify();">提交</button>
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
/*弹出修改教师界面并初始化数据*/
function teacherEdit(teacherNo) {
	$.ajax({
		url :  basePath + "Teacher/TeacherController.aspx?action=getTeacher&teacherNo=" + teacherNo,
		type : "get",
		dataType: "json",
		success : function (teacher, response, status) {
			if (teacher) {
				$("#teacher_teacherNo_edit").val(teacher.teacherNo);
				$("#teacher_password_edit").val(teacher.password);
				$("#teacher_name_edit").val(teacher.name);
				$("#teacher_sex_edit").val(teacher.sex);
				$("#teacher_bornDate_edit").val(teacher.bornDate);
				$("#teacher_teacherPhoto").val(teacher.teacherPhoto);
				$("#teacher_teacherPhotoImg").attr("src", basePath +　teacher.teacherPhoto);
				$("#teacher_telephone_edit").val(teacher.telephone);
				$("#teacher_email_edit").val(teacher.email);
				$('#teacherEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除教师信息*/
function teacherDelete(teacherNo) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Teacher/TeacherController.aspx?action=delete",
			data : {
				teacherNo : teacherNo,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Teacher/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交教师信息表单给服务器端修改*/
function ajaxTeacherModify() {
	$.ajax({
		url :  basePath + "Teacher/TeacherController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#teacherEditForm")[0]),
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

    /*出生日期组件*/
    $('.teacher_bornDate_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd',
    	minView: 2,
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

