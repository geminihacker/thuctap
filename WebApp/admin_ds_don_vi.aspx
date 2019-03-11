<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_ds_don_vi.aspx.cs" MasterPageFile="~/SiteAdmin.Master" Inherits="WebApp.admin_ds_don_vi" %>

<asp:Content ID="don_vi_1" ContentPlaceHolderID="headerTitle" runat="server">
            <title>VNPT - Quản lý danh sách đơn vị</title>
</asp:Content>
<asp:Content ID="don_vi_2" ContentPlaceHolderID="MainContent" runat="server">
     <form runat="server" id="form_dv">
          <div class="row">
                <div class="breadcrumb">
                    <a href="/Trangchu.aspx"><i class="fa fa-home"></i> Trang chủ</a>
                    <i class="fa fa-angle-right"></i>
                    <a href="/admin_ds_don_vi.aspx">Quản lý danh mục đơn vị</a>
                </div>
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myMoAdd"><i class="fa fa-plus-circle"></i> Thêm mới</button>
                <button type="submit" class="btn btn-default" style="margin-left:10px;" onclick="return confirm('Bạn có muốn load lại trang không?');"><i class="fa fa-refresh"></i> Tải lại trang</button>
          </div>
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
                 <asp:GridView ID="example" runat="server" CssClass="table table-bordered table-hover" style="width:100%" AutoGenerateColumns="False" onrowcommand="example_RowCommand">
                     <Columns>
                         <asp:BoundField DataField="ma_donvi" HeaderText="Mã đơn vị" SortExpression="ma_donvi" />
                         <asp:BoundField DataField="ten_donvi" HeaderText="Tên đơn vị" SortExpression="ten_donvi" />
                         <asp:BoundField DataField="dia_chi" HeaderText="Địa chỉ" SortExpression="dia_chi" />
                         <asp:BoundField DataField="mo_ta" HeaderText="Mô tả" SortExpression="dia_chi" />
                         <asp:TemplateField HeaderText="Chức năng">
                            <ItemTemplate>
                               <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-primary" CommandArgument='<%#Eval("ma_donvi") %>'  data-target="#myMoEdit" CommandName="chinhsua" UseSubmitBehavior="false"><i class="fa fa-edit"></i></asp:LinkButton>
                               <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("ma_donvi") %>' CssClass="btn btn-danger"  data-target="#myMoDelete" CommandName="xoa"><i class="fa fa-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
                </div>
            </div>
         <!--modal-->
          <div class="row">
                <!-- Modal add -->
                  <div class="modal fade" id="myMoAdd" role="dialog">
                    <div class="modal-dialog">
                      <div class="modal-content">
                        <div class="modal-header">
                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                          <h4 class="modal-title">Thêm loại thiết bị mới</h4>
                        </div>
                        <div class="modal-body">
                            <table class="table">
                                <tr>
                                    <td>Mã đơn bị <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_madv" runat="server" CssClass="form-control text-input" placeholder="Nhập mã đơn vị"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tên đơn bị <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_tendv" runat="server" CssClass="form-control" placeholder="Nhập tên đơn vị"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Địa chỉ <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_diachi" runat="server" CssClass="form-control" placeholder="Nhập địa chỉ"></asp:TextBox>
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
                            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click"><i class="fa fa-plus-circle"></i> Thêm mới </asp:LinkButton>
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
                          <h4 class="modal-title">Sửa đơn vị</h4>
                        </div>
                        <div class="modal-body">
                                        <table class="table">
                                            <tr>
                                                <td>Mã đơn bị <span>*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txt_madv_edit" runat="server" CssClass="form-control text-input" placeholder="Nhập mã đơn vị" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Tên đơn bị <span>*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txt_tendv_edit" runat="server" CssClass="form-control" placeholder="Nhập tên đơn vị"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Địa chỉ <span>*</span></td>
                                                <td>
                                                    <asp:TextBox ID="txt_diachi_edit" runat="server" CssClass="form-control" placeholder="Nhập địa chỉ"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Mô tả</td>
                                                <td>
                                                    <asp:TextBox ID="txt_mota_edit" runat="server" CssClass="form-control" placeholder="Nhập mô tả"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-success" OnClick="btnEdit_Click"><i class="fa fa-save"></i> Cập nhật</asp:LinkButton>
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
                            <asp:TextBox ID="txt_delete" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                            <h4 style="font-weight:normal;">Bạn có muốn xóa đơn vị <span style="padding-left:5px;padding-right:5px;color:#ff3333;"><asp:Label ID="txt_ten" runat="server" Text="Label"></asp:Label></span>không ?</h4>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnDelete_1" runat="server" CssClass="btn btn-success" OnClick="btnDelete_Click1"><i class="fa fa-trash"></i> Xóa</asp:LinkButton>
                            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-sign-out"></i> Đóng</button>
                        </div>
                      </div>
      
                    </div>
                </div><!--modal-delete-->
            </div><!--modal-->
     </form>
</asp:Content>
