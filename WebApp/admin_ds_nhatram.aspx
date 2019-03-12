<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_ds_nhatram.aspx.cs"  MasterPageFile="~/SiteAdmin.Master" Inherits="WebApp.admin_ds_nhatram" %>

<asp:Content ID="nha_tram_1" ContentPlaceHolderID="headerTitle" runat="server">
    <title>VNPT - Quản lý danh sách nhà trạm</title>
</asp:Content>
<asp:Content ID="nha_tram_2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" id="form_dv">
        <div class="row">
            <div class="breadcrumb">
                <a href="/Trangchu.aspx"><i class="fa fa-home"></i>Trang chủ</a>
                <i class="fa fa-angle-right"></i>
                <a href="admin_ds_tram.aspx">Quản lý danh mục nhà trạm</a>
            </div>
            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myMoAdd"><i class="fa fa-plus-circle"></i>Thêm mới</button>
            <button type="submit" class="btn btn-default" style="margin-left: 10px;" onclick="return confirm('Bạn có muốn load lại trang không?');"><i class="fa fa-refresh"></i>Tải lại trang</button>
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
        </div>
        <!--search-->
        <div class="row">
            <div class="table-responsive">
                <asp:GridView ID="example" runat="server" CssClass="table table-bordered table-hover" Style="width: 100%" AutoGenerateColumns="False" OnRowCommand="example_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ma_tran" HeaderText="Mã nhà trạm" SortExpression="ma_tram" />
                        <asp:BoundField DataField="ten_tram" HeaderText="Tên nhà trạm" SortExpression="ten_tram" />
                        <asp:BoundField DataField="dia_chi" HeaderText="Địa chỉ" SortExpression="dia_chi" />
                        <asp:BoundField DataField="mo_ta" HeaderText="Mô tả" SortExpression="dia_chi" />
                        <asp:BoundField DataField="ten_donvi" HeaderText="Đơn vị" SortExpression="don_vi" />
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-primary" CommandArgument='<%#Eval("ma_tran") %>' data-target="#myMoEdit" CommandName="chinhsua" UseSubmitBehavior="false"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("ma_tran") %>' CssClass="btn btn-danger" data-target="#myMoDelete" CommandName="xoa"><i class="fa fa-trash"></i></asp:LinkButton>
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
                                    <td>Mã trạm <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_add_matram" runat="server" CssClass="form-control text-input" placeholder="Nhập mã nhà trạm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tên trạm <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_add_tentram" runat="server" CssClass="form-control" placeholder="Nhập tên nhà trạm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Địa chỉ <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_add_diachi" runat="server" CssClass="form-control" placeholder="Nhập địa chỉ"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Mô tả</td>
                                    <td>
                                        <asp:TextBox ID="txt_add_mota" runat="server" CssClass="form-control" placeholder="Nhập mô tả"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td> Đơn vị </td>
                                    <td>
                                        <asp:DropDownList ID="cbx_add_dv" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                  
                            <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-success" OnClick="btnadd_Click"><i class="fa fa-plus-circle"></i> Thêm mới</asp:LinkButton>
                            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-sign-out"></i>Đóng</button>
                        </div>
                    </div>

                </div>
            </div>
            <!--modal-add-->

            <!--modal edit -->
            <div class="modal fade" id="myMoEdit" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Sửa nhà trạm</h4>
                        </div>
                        <div class="modal-body">
                            <table class="table">
                                <tr>
                                    <td>Mã trạm <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_matram_edit" runat="server" CssClass="form-control text-input" placeholder="Nhập mã nhà trạm" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tên trạm <span>*</span></td>
                                    <td>
                                        <asp:TextBox ID="txt_tentram_edit" runat="server" CssClass="form-control" placeholder="Nhập tên nhà trạm"></asp:TextBox>
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

                                <tr>
                                    <td> Đơn vị </td>
                                    <td>
                                        <asp:DropDownList ID="cbx_donvi_edit" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">

                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-success" OnClick="btnUpdate_Click"><i class="fa fa-save"></i> Cập nhật</asp:LinkButton>
                              <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-sign-out"></i>Đóng</button>
                        </div>
                    </div>

                </div>
            </div>
            <!--modal-delete-->
            <div class="modal fade" id="myMoDelete" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Thông báo</h4>
                        </div>
                        <div class="modal-body">
                            <asp:TextBox ID="txt_delete" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                            <h4 style="font-weight: normal;">Bạn có muốn xóa nhà trạm <span style="padding-left: 5px; padding-right: 5px; color: #ff3333;">
                                <asp:Label ID="txt_ten" runat="server" Text="Label"></asp:Label></span>không ?</h4>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-success" OnClick="btnDelete_Click"> <i class="fa fa-trash"></i> Xóa</asp:LinkButton>
                            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-sign-out"></i>Đóng</button>
                        </div>
                    </div>

                </div>
            </div>
            <!--modal-delete-->
        </div>
        <!--modal-->
    </form>
</asp:Content>
