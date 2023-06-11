<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="UserInfo_frontList" %>
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
<title>学生查询</title>
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
  			<li><a href="frontList.aspx">学生信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加学生</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpUserInfo" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?user_name=<%#Eval("user_name")%>"><img class="img-responsive" src="../<%#Eval("userPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		用户名: <%#Eval("user_name")%>
			     	</div>
			     	<div class="field">
	            		姓名: <%#Eval("name")%>
			     	</div>
			     	<div class="field">
	            		性别: <%#Eval("gender")%>
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
			     	<div class="field">
	            		注册时间: <%#Eval("regTime")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?user_name=<%#Eval("user_name")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="userInfoEdit('<%#Eval("user_name")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="userInfoDelete('<%#Eval("user_name")%>');" style="display:none;">删除</a>
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
    		<h1>学生查询</h1>
		</div>
			<div class="form-group">
				<label for="user_name">用户名:</label>
				<asp:TextBox ID="user_name" runat="server"  CssClass="form-control" placeholder="请输入用户名"></asp:TextBox>
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
<div id="userInfoEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;学生信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="userInfoEditForm" id="userInfoEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="userInfo_user_name_edit" class="col-md-3 text-right">用户名:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="userInfo_user_name_edit" name="userInfo.user_name" class="form-control" placeholder="请输入用户名" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="userInfo_password_edit" class="col-md-3 text-right">登录密码:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="userInfo_password_edit" name="userInfo.password" class="form-control" placeholder="请输入登录密码">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="userInfo_name_edit" class="col-md-3 text-right">姓名:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="userInfo_name_edit" name="userInfo.name" class="form-control" placeholder="请输入姓名">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="userInfo_gender_edit" class="col-md-3 text-right">性别:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="userInfo_gender_edit" name="userInfo.gender" class="form-control" placeholder="请输入性别">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="userInfo_bornDate_edit" class="col-md-3 text-right">出生日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date userInfo_bornDate_edit col-md-12" data-link-field="userInfo_bornDate_edit" data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="userInfo_bornDate_edit" name="userInfo.bornDate" size="16" type="text" value="" placeholder="请选择出生日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="userInfo_userPhoto_edit" class="col-md-3 text-right">用户照片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="userInfo_userPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="userInfo_userPhoto" name="userInfo.userPhoto"/>
			    <input id="userPhotoFile" name="userPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="userInfo_telephone_edit" class="col-md-3 text-right">联系电话:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="userInfo_telephone_edit" name="userInfo.telephone" class="form-control" placeholder="请输入联系电话">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="userInfo_email_edit" class="col-md-3 text-right">邮箱:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="userInfo_email_edit" name="userInfo.email" class="form-control" placeholder="请输入邮箱">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="userInfo_address_edit" class="col-md-3 text-right">家庭地址:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="userInfo_address_edit" name="userInfo.address" class="form-control" placeholder="请输入家庭地址">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="userInfo_regTime_edit" class="col-md-3 text-right">注册时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date userInfo_regTime_edit col-md-12" data-link-field="userInfo_regTime_edit">
                    <input class="form-control" id="userInfo_regTime_edit" name="userInfo.regTime" size="16" type="text" value="" placeholder="请选择注册时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#userInfoEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxUserInfoModify();">提交</button>
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
/*弹出修改学生界面并初始化数据*/
function userInfoEdit(user_name) {
	$.ajax({
		url :  basePath + "UserInfo/UserInfoController.aspx?action=getUserInfo&user_name=" + user_name,
		type : "get",
		dataType: "json",
		success : function (userInfo, response, status) {
			if (userInfo) {
				$("#userInfo_user_name_edit").val(userInfo.user_name);
				$("#userInfo_password_edit").val(userInfo.password);
				$("#userInfo_name_edit").val(userInfo.name);
				$("#userInfo_gender_edit").val(userInfo.gender);
				$("#userInfo_bornDate_edit").val(userInfo.bornDate);
				$("#userInfo_userPhoto").val(userInfo.userPhoto);
				$("#userInfo_userPhotoImg").attr("src", basePath +　userInfo.userPhoto);
				$("#userInfo_telephone_edit").val(userInfo.telephone);
				$("#userInfo_email_edit").val(userInfo.email);
				$("#userInfo_address_edit").val(userInfo.address);
				$("#userInfo_regTime_edit").val(userInfo.regTime);
				$('#userInfoEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除学生信息*/
function userInfoDelete(user_name) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "UserInfo/UserInfoController.aspx?action=delete",
			data : {
				user_name : user_name,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "UserInfo/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交学生信息表单给服务器端修改*/
function ajaxUserInfoModify() {
	$.ajax({
		url :  basePath + "UserInfo/UserInfoController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#userInfoEditForm")[0]),
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
    $('.userInfo_bornDate_edit').datetimepicker({
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
    /*注册时间组件*/
    $('.userInfo_regTime_edit').datetimepicker({
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

