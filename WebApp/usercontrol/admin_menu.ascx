<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admin_menu.ascx.cs" Inherits="MyNews.admin_menu" %>

<link href="css/font-awesome.min.css" rel="stylesheet" />

<nav class="navbar navbar-inverse" role="banner" style="z-index: 999; border-bottom: 2px solid  #005395">
    <div class="container" style="height: 30px">
        <div class="row">


            <div class="navbar-header col-md-1  pright-0" style="padding-top: 5px;">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

                <a class="navbar-brand"  title="Website" href="/admin_main.aspx">
                   <%-- <img src="/images/logos.png" alt="logo" height="65px">--%>
                </a>
            </div>

            <div class="collapse navbar-collapse navbar-left col-md-12" style="background-color: #fff;">
                <div class="row">
                    <div class="col-md-12">
                        <ul class="nav navbar-nav">
                            <li class="mobile"><a href="/trangchu.aspx">Trang chủ </a></li>
                            <li class="mobile"><a href="/tracuu.aspx">Tra cứu </a></li>
                           
                            <li><a style="color: #fff" href="/dangnhap">Thoát </a></li>
                        </ul>


                    </div>

                </div>

            </div>
        </div>
    </div>

</nav>

