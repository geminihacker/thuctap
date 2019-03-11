<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_add_Account.aspx.cs" MasterPageFile="~/SiteAdmin.Master" Inherits="WebApp.Admin.admin_add_Account" %>
<asp:Content ID="Account_1" ContentPlaceHolderID="headerTitle" runat="server">
    <title>VNPT - Danh sách tài khoản</title>
</asp:Content>
<asp:Content ID="Account_2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="row">
                <div class="breadcrumb">
                    <a href="/Trangchu.aspx"><i class="fa fa-home"></i> Trang chủ</a>
                    <i class="fa fa-angle-right"></i>
                    <a href="/Admin/admin_add_Account.aspx">Danh sách tài khoản</a>
                </div>
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal"><i class="fa fa-plus-circle"></i> Thêm mới tài khoản</button>
                <button type="submit" class="btn btn-default" style="margin-left:10px;" onclick="return confirm('Bạn có muốn load lại trang không?');"><i class="fa fa-refresh"></i> Tải lại trang</button>
          </div><!--breadcrum-->
         <div class="row" id="form">
                  <div class="col-md-6 col-xs-4 col-sm-4">
                      <div class="form-group">
                          <asp:DropDownList ID="SelectItem" runat="server" CssClass="form-control">
                              <asp:ListItem Text="-- Tìm kiếm theo --" Value="true"></asp:ListItem>
                              <asp:ListItem Text="Mã thiết bị" Value="true"></asp:ListItem>
                              <asp:ListItem Text="Tên thiết bị" Value="false"></asp:ListItem>
                              <asp:ListItem Text="Địa chỉ" Value="false"></asp:ListItem>
                           </asp:DropDownList>
                      </div>
                  </div>
                  <div class="col-md-6 col-xs-12 col-sm-12">
                     <div class="form-group" id="form__search">
                          <asp:TextBox ID="txt_search" runat="server" placeholder="Nhập từ khóa tìm kiếm" CssClass="form-control"></asp:TextBox>
                         <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success"><i class="fa fa-search"></i></asp:LinkButton>
                     </div>
                  </div>
              </div><!--search-->
        <div class="row">
            <div class="table-responsive">
                  <asp:GridView ID="example" runat="server" CssClass="table table-bordered table-hover" style="width:100%" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="name_user" HeaderText="Tên tài khoản" SortExpression="ma_donvi" />
                            <asp:BoundField DataField="tenhienthi" HeaderText="Tên hiển thị" SortExpression="ten_donvi" />
                            <asp:BoundField DataField="sdt" HeaderText="Số điện thoại" SortExpression="dia_chi" />
                            <asp:BoundField DataField="ten_donvi" HeaderText="Đơn vị" SortExpression="dia_chi" />
                            <asp:BoundField DataField="gioitinhA" HeaderText="Giới tính" SortExpression="dia_chi" />
                            <asp:BoundField DataField="Issuper" HeaderText="Quyền hạn" SortExpression="dia_chi" />
                            <asp:TemplateField HeaderText="Chức năng">
                                <ItemTemplate>
                                     <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='' CssClass="btn btn-secondary"  data-target="#myMoDelete" title="Cập nhật mật khẩu"><i class="fa fa-key"></i></asp:LinkButton>
                                     <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-primary"  data-toggle="modal" data-target="#myMoEdit" CommandArgument='' title="Sửa tài khoản" ><i class="fa fa-edit"></i></asp:LinkButton>
                                     <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='' CssClass="btn btn-danger"  data-target="#myMoDelete" title="Xóa tài khoản" ><i class="fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
                                     <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='' CssClass="btn btn-warning"  data-target="#myMoDelete" title="Khóa cài khoản"><i class="fa fa-lock"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='' CssClass="btn btn-success"  data-target="#myMoDelete" title="Cài đặt tài khoản"><i class="fa fa-cog"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                         </Columns>
                   </asp:GridView>
              </div>
            </div>
        <div class="row">
                <!-- Modal add -->
                  <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">
                      <div class="modal-content">
                        <div class="modal-header">
                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                          <h4 class="modal-title">Thêm tài khoản mới</h4>
                        </div>
                        <div class="modal-body">
                            <table class="table">
                                <tr>
                                    <td>Tên tài khoản <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_username" runat="server" CssClass="form-control text-input" placeholder="Nhập tên tài khoản"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tên hiển thị <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_name" runat="server" CssClass="form-control" placeholder="Nhập tên hiển thị"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Mật khẩu<span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_password" runat="server" CssClass="form-control text-input" placeholder="Nhập mật khẩu" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ngày sinh<span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_ngaysinh" runat="server" CssClass="form-control text-input" TextMode="Date"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Mô tả</td>
                                    <td>
                                        <asp:TextBox ID="txt_mota" runat="server" CssClass="form-control" placeholder="Nhập mô tả"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-success"><i class="fa fa-plus-circle"></i> Thêm</asp:LinkButton>
                          <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-sign-out"></i> Đóng</button>
                        </div>
                      </div>
      
                    </div>
                </div><!--modal-add-->

                <!--modal edit -->
              <div class="modal fade" id="myMoEdit" role="dialog">
                    <div class="modal-dialog">
                      <div class="modal-content">
                        <div class="modal-header">
                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                          <h4 class="modal-title">Sửa đơn vị mới</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Repeater ID="rptedit" runat="server">
                                   <ItemTemplate>
                                        <table class="table">
                                            <tr>
                                                <td>Mã đơn bị <span>*</span></td>
                                                <td>
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control text-input" placeholder="Nhập mã đơn vị"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Tên đơn bị <span>*</span></td>
                                                <td>
                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Nhập tên đơn vị"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Địa chỉ <span>*</span></td>
                                                <td>
                                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Nhập địa chỉ"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Mô tả</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Nhập mô tả"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                       </ItemTemplate>
                                 </asp:Repeater>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success"><i class="fa fa-save"></i> Cập nhật</asp:LinkButton>
                            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-sign-out"></i> Đóng</button>
                        </div>
                      </div>
      
                    </div>
                </div><!--modal-delete-->
              <div class="modal fade" id="myMoDelete" role="dialog">
                    <div class="modal-dialog">
                      <div class="modal-content">
                        <div class="modal-header">
                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                          <h4 class="modal-title">Thông báo</h4>
                        </div>
                        <div class="modal-body">
                           <h3>Ban có muốn xóa đơn vị này không ?</h3>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnDelete_1" runat="server" CssClass="btn btn-success"><i class="fa fa-trash"></i> Xóa</asp:LinkButton>
                            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-sign-out"></i> Đóng</button>
                        </div>
                      </div>
      
                    </div>
                </div><!--modal-delete-->
            </div><!--modal-->
    </form>
</asp:Content>
