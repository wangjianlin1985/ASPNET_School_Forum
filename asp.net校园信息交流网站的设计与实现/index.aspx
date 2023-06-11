<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
%>
<!DOCTYPE html>
<html lang="zh-CN">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <title>��Ʒ��Ŀ���-��ҳ</title>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
</head>
<body> 
<div class="container">
 <uc:header ID="header" runat="server" />
 <!-- ����ֲ���ʼ -->
  <section id="main_ad" class="carousel slide" data-ride="carousel">
    <!-- �����С��㣬�ָʾ�� -->
    <ol class="carousel-indicators">
      <li data-target="#main_ad" data-slide-to="0" class="active"></li>
      <li data-target="#main_ad" data-slide-to="1"></li>
      <li data-target="#main_ad" data-slide-to="2"></li>
      <li data-target="#main_ad" data-slide-to="3"></li>
    </ol>
    <!-- �ֲ��� -->
    <div class="carousel-inner" role="listbox">  
      <div class="item active" data-image-lg="<%=basePath %>images/slider/slide_01_2000x410.jpg" data-image-xs="<%=basePath %>images/slider/slide_01_640x340.jpg"></div>
      <div class="item" data-image-lg="<%=basePath %>images/slider/slide_02_2000x410.jpg" data-image-xs="<%=basePath %>images/slider/slide_02_640x340.jpg"></div>
      <div class="item" data-image-lg="<%=basePath %>images/slider/slide_03_2000x410.jpg" data-image-xs="<%=basePath %>images/slider/slide_03_640x340.jpg"></div>
      <div class="item" data-image-lg="<%=basePath %>images/slider/slide_04_2000x410.jpg" data-image-xs="<%=basePath %>images/slider/slide_04_640x340.jpg"></div>
    </div> 
    <!-- ���ư�ť -->
    <a class="left carousel-control" href="#main_ad" role="button" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
      <span class="sr-only">��һҳ</span>
    </a>
    <a class="right carousel-control" href="#main_ad" role="button" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
      <span class="sr-only">��һҳ</span>
    </a>
  </section>
  <!-- /����ֲ����� -->
  

<!-- ��ɫ���ܿ�ʼ -->
  <section id="tese">
    <div class="container">
      <div class="row">
        <div class="col-xs-6 col-md-4">
          <a href="#">
            <div class="media">
              <div class="media-left">
                <i class="icon-uniE907"></i>
              </div>
              <div class="media-body">
                <h4 class="media-heading">��Ʒ�������</h4>
                <p>������Ѿ�ͨ���˾��ĵ���</p>
              </div>
            </div>
          </a>
        </div>
        <div class="col-xs-6 col-md-4">
          <a href="#">
            <div class="media">
              <div class="media-left">
                <i class="icon-uniE907"></i>
              </div>
              <div class="media-body">
                <h4 class="media-heading">��Ʒ�������</h4>
                <p>������Ѿ�ͨ���˾��ĵ���</p>
              </div>
            </div>
          </a>
        </div>
        <div class="col-xs-6 col-md-4">
          <a href="#">
            <div class="media">
              <div class="media-left">
                <i class="icon-uniE907"></i>
              </div>
              <div class="media-body">
                <h4 class="media-heading">��Ʒ�������</h4>
                <p>������Ѿ�ͨ���˾��ĵ���</p>
              </div>
            </div>
          </a>
        </div>
        <div class="col-xs-6 col-md-4">
          <a href="#">
            <div class="media">
              <div class="media-left">
                <i class="icon-uniE907"></i>
              </div>
              <div class="media-body">
                <h4 class="media-heading">��Ʒ�������</h4>
                <p>������Ѿ�ͨ���˾��ĵ���</p>
              </div>
            </div>
          </a>
        </div>
        <div class="col-xs-6 col-md-4">
          <a href="#">
            <div class="media">
              <div class="media-left">
                <i class="icon-uniE907"></i>
              </div>
              <div class="media-body">
                <h4 class="media-heading">��Ʒ�������</h4>
                <p>������Ѿ�ͨ���˾��ĵ���</p>
              </div>
            </div>
          </a>
        </div>
        <div class="col-xs-6 col-md-4">
          <a href="#">
            <div class="media">
              <div class="media-left">
                <i class="icon-uniE907"></i>
              </div>
              <div class="media-body">
                <h4 class="media-heading">��Ʒ�������</h4>
                <p>������Ѿ�ͨ���˾��ĵ���</p>
              </div>
            </div>
          </a>
        </div>
      </div>
    </div>
  </section>
  <!-- /��ɫ���� ����-->

 <uc:footer ID="footer" runat="server" />

</div>
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>js/index.js"></script>
</body>
</html>
