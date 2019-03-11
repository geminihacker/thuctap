<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admin__menu.ascx.cs" Inherits="WebApp.usercontrol.admin__menu" %>
 <nav class="sidebar sidebar-offcanvas" id="sidebar">
        <ul class="nav">
          <li class="nav-item nav-profile">
            <div class="nav-link">
              <div class="user-wrapper">
                <div class="profile-image">
                    <asp:Image ID="avatar_user" runat="server" />
                </div>
                <div class="text-wrapper">
                    <p class="profile-name">
                        <asp:Label ID="username" runat="server" Text="Label"></asp:Label>
                    </p>
                  <div>
                    <small class="designation text-muted">Đang hoạt động</small>
                    <span class="status-indicator online"></span>
                  </div>
                </div>
              </div>
            </div>
          </li>
          <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="/Trangchu.aspx" aria-expanded="false" >
              <i class="menu-icon mdi mdi-television"></i>
              <span class="menu-title">Bảng tin</span>
            </a>
            </li>
             <li class="nav-item">
                <a class="nav-link" data-toggle="collapse" href="#ui-post" aria-expanded="false" aria-controls="ui-basic">
                  <i class="menu-icon fa fa-thumb-tack"></i>
                  <span class="menu-title">Quản lý thông báo</span>
                  <i class="menu-arrow"></i>
                </a>
                <div class="collapse" id="ui-post">
                  <ul class="nav flex-column sub-menu">
                    <li class="nav-item">
                      <a class="nav-link" href="/admin_ds_don_vi.aspx"><i class="fa fa-circle-o" style="padding-right:5px;font-size:9px;"></i> Thêm bài viết mới</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="/"><i class="fa fa-circle-o" style="padding-right:5px;font-size:9px;"></i> Danh mục</a>
                    </li>
                  </ul>
                </div>
          </li>
           <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="/Trangchu.aspx" aria-expanded="false" >
              <i class="menu-icon fa fa-laptop"></i>
              <span class="menu-title">Quản lý thiết bị</span>
            </a>
            </li>
           <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="#ui-basic" aria-expanded="false" aria-controls="ui-basic">
              <i class="menu-icon fa fa-bars"></i>
              <span class="menu-title">Quản lý danh mục</span>
              <i class="menu-arrow"></i>
            </a>
            <div class="collapse" id="ui-basic">
              <ul class="nav flex-column sub-menu">
                <li class="nav-item">
                  <a class="nav-link" href="/admin_ds_don_vi.aspx"><i class="fa fa-circle-o" style="padding-right:5px;font-size:9px;"></i> Danh mục đơn vị</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="/Admin/admin_loai_thietbi.aspx"><i class="fa fa-circle-o" style="padding-right:5px;font-size:9px;"></i> Danh mục nhà trạm</a>
                </li>
                 <li class="nav-item">
                  <a class="nav-link" href="/Admin/admin_loai_thietbi.aspx"><i class="fa fa-circle-o" style="padding-right:5px;font-size:9px;"></i> Danh mục loại thiết bị</a>
                </li>
              </ul>
            </div>
          </li>
        <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="#ui-user" aria-expanded="false" aria-controls="ui-user">
              <i class="menu-icon fa fa-cog"></i>
              <span class="menu-title">Quản lý người dùng</span>
              <i class="menu-arrow"></i>
            </a>
            <div class="collapse" id="ui-user">
              <ul class="nav flex-column sub-menu">
                <li class="nav-item">
                  <a class="nav-link" href="/"><i class="fa fa-circle-o" style="padding-right:5px;font-size:9px;"></i> Thông tin tài khoản</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="/"><i class="fa fa-circle-o" style="padding-right:5px;font-size:9px;"></i> Nhóm phân quyền</a>
                </li>
                 <li class="nav-item">
                  <a class="nav-link" href="/Admin/admin_add_Account.aspx"><i class="fa fa-circle-o" style="padding-right:5px;font-size:9px;"></i> Danh sách tài khoản</a>
                </li>
              </ul>
            </div>
          </li>
        </ul>
      </nav>