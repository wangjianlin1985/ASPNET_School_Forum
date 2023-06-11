/// <reference path="Jquery.doc.js"/>
$(function() {
    var x = 10;
    var y = 10;
    // 左侧菜单效果
    $('.Menu').click(function() {
        var $NowMenu = $(this).next('.MenuNote');
        $('.MenuNote').hide(400, function() { });
        if ($NowMenu.is(":visible")) {
            $NowMenu.hide(300, function() { });
        } else {
            $NowMenu.show(500, function() { });
        }
    });

    $("tbody>tr:even").css("background", "#F0F0E8");
    $("tbody>tr").mouseover(function() {
        $(this).css("background", "#DAE9FB");
    });
    $("tbody>tr").mouseout(function() {
        $("tbody>tr:even").css("background", "#F0F0E8");
        $("tbody>tr:odd").css("background", "");
    });

    $("#BtnClassSave").click(function() {
        if ($.trim($("#txtClassName").val()).length == 0) {
            alert("类别名称不能为空...");
            $("#txtClassName").focus();
            return false;
        }
    });
    
     $("#BtnLeaderInfoSave").click(function() {
        if ($.trim($("#txtLeaderName").val()).length == 0) {
            alert("领导姓名不能为空...");
            $("#txtLeaderName").focus();
            return false;
        }
        else if($.trim($("#txtLeaderDuties").val()).length == 0){
            alert("领导职位不能为空...");
            $("#txtLeaderDuties").focus();
            return false;
        }
      else if($.trim($("#txtTelePone").val()).length == 0){
            alert("领导电话号码不能为空...");
            $("#txtTelePone").focus();
            return false;
        }
        else if($.trim($("#txtWorkContent").val()).length == 0){
            alert("领导职责范围不能为空...");
            $("#txtWorkContent").focus();
            return false;
        }
       
    });
    $(".DelClass").click(function() {
        if (confirm("确定删除该信息？该信息下的所有相关信息都将删除！")) {
            return true;
        }
        return false;
    })
    $("#BtnAllSelect").click(function() {
        if ($("#BtnAllSelect").val() == "全选") {
            $("#BtnAllSelect").val("反选");
            $("[name=CheckMes]:checkbox").attr("checked", true);
        }
        else {
            $("#BtnAllSelect").val("全选");
            $("[name=CheckMes]:checkbox").each(function() {
                //$(this).attr("checked", !$(this).attr("checked"));
                this.checked = !this.checked;
            })
        }
    })
    $("#BtnAllDel").click(function() {
        if (confirm("你确定删除所有选中的信息？")) {
            var checkValue = "";
            $("[name=CheckMes]:checkbox:checked").each(function() {
                if ($.trim($(this).val()).length > 0) {
                    checkValue += "," + $.trim($(this).val());
                }
            })
            if (checkValue.length == 0) {
                alert("你没有选择任何信息，请先选中要删除的信息！");
                return false;
            }
            else {
                $("#HSelectID").val(checkValue.substr(1));
            }
            return true;
        }
        else {
            return false;
        }
    })
    $("td.TIP").mouseover(function(e) {
        this.myTitle = this.title;
        this.title = "";
        var toolTip = "<div id='tooltip'>" + this.myTitle + "</div>";
        $("body").append(toolTip);
        $("#tooltip").css({
            "position": "absolute",
            "padding": "5px",
            "background": "#F0F0E8",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        }).show(200);
    }).mouseout(function() {
        this.title = this.myTitle;
        $("#tooltip").remove();
    }).mousemove(function(e) {
        $("#tooltip").css({
            "background": "#F0F0E8",
            "padding": "5px",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        })
    })
    $("#BtnProSave").click(function() {
        if ($.trim($("#txtProName").val()).length == 0) {
            alert("请填写产品名称信息...");
            $("#txtProName").focus();
            return false;
        }
         else if ($.trim($("#HImageName").val()) == "noImage.gif") {
            if (!confirm("检测到你没有上传产品图片，你确定不需要上传图片吗？")) {
                $("#UploadImg").click();
                return false;
            }
        }
       
    })
      $("#BtnMgSave").click(function() {
       if($.trim($("#DDLMain").val())=="=请选择类型="){
         alert("检测到你没有业务分类信息，请您选择分类信息");
          $("#NpType").focus();
         return false;
       }else if ($.trim($("#txtProName").val()).length == 0) {
            alert("请填写报刊名称信息...");
            $("#txtProName").focus();
            return false;txtMgIntro
        }else if ($.trim($("#HImageName").val()) == "noImage.gif") {
            if (!confirm("检测到你没有上传报刊封面，你确定不需要上传该封面吗？")) {
                $("#UploadImg").click();
                return false;
            }
        } else if (FCKeditorAPI.GetInstance("txtMgIntro").GetXHTML().length == 0) {
            if (!confirm("检测到你没有填写任何报刊介绍，你确定不填写报刊介绍吗？")) {
                FCKeditorAPI.GetInstance('txtMgIntro').Focus();
                return false;
            }
        }
       
    })
    $("#BtnPicSave").click(function() {
       if ($.trim($("#txtTitle").val()).length == 0) {
            alert("请填写图片新闻标题...");
            $("#txtTitle").focus();
            return false;
        }
        else if ($.trim($("#HImageName").val()) == "noImage.gif") {
            alert("检测到你没有上传图片，请您上传图片？");
                $("#UploadImg").click();
                return false;
        }
        else if (FCKeditorAPI.GetInstance("txtProName").GetXHTML().length == 0) {
            if (!confirm("检测到你没有填写任何信息内容，你确定不填写资讯内容吗？")) {
                FCKeditorAPI.GetInstance('txtProName').Focus();
                return false;
            }
        }
       
    })
     $("#BtnPostPicSave").click(function() {
       if ($.trim($("#HImageName").val()) == "noImage.gif") {
            alert("检测到你没有上传图片，请您上传图片？");
                $("#UploadImg").click();
                return false;
        }
    })
 $("#BtnUpLoad").click(function() {
        if ($.trim($("#UploadImg").val()).length == 0) {
            alert("请先选择要上传的图片...");
            $("#UploadImg").click();
            return false;
        }
    })
    
    $("#BtnAddMg").click(function() {
        location.href = "M_EditNewsPapers.aspx";
    })  
    $("#BtnAddPro").click(function() {
        location.href = "M_EditPictInfo.aspx";
    })
    $("#UploadFiles").click(function() {
        location.href = "M_EditUserFiles.aspx";
    })
    $("BtntoIntro").click(function(){
     location.href="M_NewsPapersIntrod.aspx";
    })
     $("#BtnPicAdd").click(function() {
        location.href = "M_EditPsExpress.aspx";
    })
     $("#BtnUsersAdd").click(function() {
        location.href = "M_EditUsersInfo.aspx";
    })
    
    $(".SeeImg").mouseover(function(e) {
        var toolTip = "<div id='tooltip'><img src=" +  this.alt + "/></div>";
        $("body").append(toolTip);
        $("#tooltip").css({
            "position": "absolute",
            "padding": "5px",
            "background": "#F0F0E8",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        }).show(200);
    }).mouseout(function() {
        $("#tooltip").remove();
    }).mousemove(function(e) {
        $("#tooltip").css({
            "background": "#F0F0E8",
            "padding": "5px",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        })
    })

    $("#BtnLinkSave").click(function() {
        if ($.trim($("#txtWebLinkImage").val()).length == 0) {
            alert("链接名称不能为空...");
            $("#txtWebLinkImage").focus();
            return false;
        }
        else if (($.trim($("#txtWebLinkTitle").val()).length == 0)) {
            alert("链接网址不能为空...");
            $("#txtWebLinkTitle").focus();
            return false;
        }else if($("#txtWebLinkUrl").val()=="http://"){
         alert("链接网址不能为空...");
            $("#txtWebLinkUrl").focus();
            return false;
        }
    })
    $("#BtnNewsSave").click(function () {
        /*
        if ($.trim($("#txtAuthor").val()).length == 0) {
            alert("你还录入新闻的作者信息，无法添加新闻...");
           $("#txtAuthor").focus();
            return false;
        } 
        else if ($.trim($("#txtFrom").val()).length == 0) {
            alert("你还未选择新闻的来源信息，无法添加新闻...");
            $("#txtFrom").focus();
            return false;
        } 
        else if ($.trim($("#txtTitle").val()).length == 0) {
            alert("请填写新闻的标题信息...");
            $("#txtProName").focus();
            return false;
        }else if (FCKeditorAPI.GetInstance("txtProNote").GetXHTML().length == 0) {
            if (!confirm("检测到你没有填写任何信息内容，你确定不填写资讯内容吗？")) {
                FCKeditorAPI.GetInstance('txtProNote').Focus();
                return false;
            }
        }*/
        
    })
     $("#BtnSaveFiles").click(function() {
      if ($.trim($("#HImageName").val()) == "noImage.gif") {
              alert("请选择要上传的文件...");
             $("#UploadImg").click();
                return false;
        }else if (FCKeditorAPI.GetInstance("txt_FilesIntrod").GetXHTML().length == 0) {
            alert("请输入文件描述...");
                FCKeditorAPI.GetInstance('txt_FilesIntrod').Focus();
                return false;
        }
        
    })
     $("#BtnAgentSave").click(function() {
        if ($.trim($("#txtAgentName").val()).length == 0) {
            alert("网点名称不能为空...");
            $("#txtAgentName").focus();
            return false;
        }
        else if (($.trim($("#txtAgentAddress").val()).length == 0)) {
            alert("网点地址不能为空...");
            $("#txtAgentAddress").focus();
            return false;
        }
         else if (($.trim($("#txtAgentService").val()).length == 0)) {
            alert("网点主营业务不能为空...");
            $("#txtAgentService").focus();
            return false;
        }
         else if (($.trim($("#txtAgentPhone").val()).length == 0)) {
            alert("网点电话号码不能为空...");
            $("#txtAgentPhone").focus();
            return false;
        } else if (($.trim($("#txtAgentCode").val()).length == 0)) {
            alert("网点邮政编码不能为空...");
            $("#txtAgentCode").focus();
            return false;
        }
        else if (($.trim($("#txtWorkTime").val()).length == 0)) {
            alert("网点营业时间不能为空...");
            $("#txtWorkTime").focus();
            return false;
        }
    })
    $(".SeeLinkImage").mouseover(function(e) {
        var toolTip = "<div id='tooltip'><img src=" + this.myTitle + " /></div>";
        $("body").append(toolTip);
        $("#tooltip").css({
            "position": "absolute",
            "padding": "5px",
            "background": "#F0F0E8",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        }).show(200);
    }).mouseout(function() {
        $("#tooltip").remove();
    }).mousemove(function(e) {
        $("#tooltip").css({
            "background": "#F0F0E8",
            "padding": "5px",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        })
    })
    $("#BtnLeaveSave").click(function() {
        if ($.trim($("#txtReBackNote").val()).length == 0) {
            alert("你可以选择不回复，但不允许回复空信息...");
            $("#txtReBackNote").focus();
            return false;
        }
    })

    $("#BtnPass").click(function() {
        if ($.trim($("#txtPass").val()).length == 0) {
            alert("解锁码不能为空，请认真对待！！");
            $("#txtPass").focus();
            return false;
        }
        if ($.trim($("#txtCheck").val()).length == 0) {
            alert("验证码不能为空，请认真对待！！");
            $("#txtCheck").focus();
            return false;
        }
    })
    $("#BtnUpdatePass").click(function() {
        if ($.trim($("#txtOldPass").val()).length == 0) {
            alert("原密码不能为空！！");
            $("#txtOldPass").focus();
            return false;
        }
        if ($.trim($("#txtNewPass").val()).length == 0) {
            alert("新密码不能为空！！");
            $("#txtNewPass").focus();
            return false;
        }
        if ($.trim($("#txtCheckPass").val()).length == 0) {
            alert("确认密码不能为空！！");
            $("#txtCheckPass").focus();
            return false;
        }
        if ($.trim($("#txtCheckPass").val()) != $.trim($("#txtNewPass").val())) {
            alert("确认密码与原密码不符，请重新输入确认密码！！");
            $("#txtCheckPass").focus();
            $("#txtCheckPass").val("");
            return false;
        }
    })
     $("#txtProNote").keyup(function() {
        if ($.trim($("#txtProNote").val()).length > 500) {
            $("#txtProNote").val($("#txtProNote").val().substring(0, 499));
        }
    })

    $("#BtnBringSave").click(function() {
        if ($.trim($("#txtProName").val()).length == 0) {
            alert("请填写发布标题...");
            $("#txtProName").focus();
            return false;
        } else if ($.trim($("#HImageName").val()) == "noImage.gif") {
            if (!confirm("检测到你没有上传图片，你确定不需要上传图片吗？")) {
                $("#UploadImg").click();
                return false;
            }
        } else if ($.trim($("#txtProNote").val()).length == 0) {
            alert("简介信息请务必填写...");
            $("#txtProNote").focus();
            return false;
        }
        return true;
    })
});