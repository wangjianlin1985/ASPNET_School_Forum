<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="PhotoInfo_frontList" %>
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
<title>照片查询</title>
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
  			<li><a href="frontList.aspx">照片信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加照片</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpPhotoInfo" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?photoId=<%#Eval("photoId")%>"><img class="img-responsive" src="../<%#Eval("photoImage")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		照片id: <%#Eval("photoId")%>
			     	</div>
			     	<div class="field">
	            		照片分类:<%#GetPhotoClassphotoClassObj(Eval("photoClassObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		照片名称: <%#Eval("photoName")%>
			     	</div>
			     	<div class="field">
	            		发布用户:<%#GetUserInfouserObj(Eval("userObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		发布时间: <%#Eval("addTime")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?photoId=<%#Eval("photoId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="photoInfoEdit('<%#Eval("photoId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="photoInfoDelete('<%#Eval("photoId")%>');" style="display:none;">删除</a>
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
    		<h1>照片查询</h1>
		</div>
            <div class="form-group">
            	<label for="photoClassObj_photoClassId">照片分类：</label>
                <asp:DropDownList ID="photoClassObj" runat="server"  CssClass="form-control" placeholder="请选择照片分类"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="photoName">照片名称:</label>
				<asp:TextBox ID="photoName" runat="server"  CssClass="form-control" placeholder="请输入照片名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="userObj_user_name">发布用户：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择发布用户"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="photoInfoEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;照片信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="photoInfoEditForm" id="photoInfoEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="photoInfo_photoId_edit" class="col-md-3 text-right">照片id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="photoInfo_photoId_edit" name="photoInfo.photoId" class="form-control" placeholder="请输入照片id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="photoInfo_photoClassObj_photoClassId_edit" class="col-md-3 text-right">照片分类:</label>
		  	 <div class="col-md-9">
			    <select id="photoInfo_photoClassObj_photoClassId_edit" name="photoInfo.photoClassObj.photoClassId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="photoInfo_photoName_edit" class="col-md-3 text-right">照片名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="photoInfo_photoName_edit" name="photoInfo.photoName" class="form-control" placeholder="请输入照片名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="photoInfo_photoImage_edit" class="col-md-3 text-right">照片文件:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="photoInfo_photoImageImg" border="0px"/><br/>
			    <input type="hidden" id="photoInfo_photoImage" name="photoInfo.photoImage"/>
			    <input id="photoImageFile" name="photoImageFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="photoInfo_userObj_user_name_edit" class="col-md-3 text-right">发布用户:</label>
		  	 <div class="col-md-9">
			    <select id="photoInfo_userObj_user_name_edit" name="photoInfo.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="photoInfo_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date photoInfo_addTime_edit col-md-12" data-link-field="photoInfo_addTime_edit">
                    <input class="form-control" id="photoInfo_addTime_edit" name="photoInfo.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#photoInfoEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxPhotoInfoModify();">提交</button>
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
/*弹出修改照片界面并初始化数据*/
function photoInfoEdit(photoId) {
	$.ajax({
		url :  basePath + "PhotoInfo/PhotoInfoController.aspx?action=getPhotoInfo&photoId=" + photoId,
		type : "get",
		dataType: "json",
		success : function (photoInfo, response, status) {
			if (photoInfo) {
				$("#photoInfo_photoId_edit").val(photoInfo.photoId);
				$.ajax({
					url: basePath + "PhotoClass/PhotoClassController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(photoClasss,response,status) { 
						$("#photoInfo_photoClassObj_photoClassId_edit").empty();
						var html="";
		        		$(photoClasss).each(function(i,photoClass){
		        			html += "<option value='" + photoClass.photoClassId + "'>" + photoClass.photoClassName + "</option>";
		        		});
		        		$("#photoInfo_photoClassObj_photoClassId_edit").html(html);
		        		$("#photoInfo_photoClassObj_photoClassId_edit").val(photoInfo.photoClassObjPri);
					}
				});
				$("#photoInfo_photoName_edit").val(photoInfo.photoName);
				$("#photoInfo_photoImage").val(photoInfo.photoImage);
				$("#photoInfo_photoImageImg").attr("src", basePath +　photoInfo.photoImage);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#photoInfo_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#photoInfo_userObj_user_name_edit").html(html);
		        		$("#photoInfo_userObj_user_name_edit").val(photoInfo.userObjPri);
					}
				});
				$("#photoInfo_addTime_edit").val(photoInfo.addTime);
				$('#photoInfoEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除照片信息*/
function photoInfoDelete(photoId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "PhotoInfo/PhotoInfoController.aspx?action=delete",
			data : {
				photoId : photoId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "PhotoInfo/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交照片信息表单给服务器端修改*/
function ajaxPhotoInfoModify() {
	$.ajax({
		url :  basePath + "PhotoInfo/PhotoInfoController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#photoInfoEditForm")[0]),
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
    $('.photoInfo_addTime_edit').datetimepicker({
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

