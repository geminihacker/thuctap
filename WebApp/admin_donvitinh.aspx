<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_donvitinh.aspx.cs" MasterPageFile="~/SiteAdmin.Master" Inherits="MyNews.admin_donvitinh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/jquery-1.11.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

    <div class="container">
        <div class="row" style="margin: 0px">



            <div class="row" style="margin: 0px">
                <div class="title_top11">
                    <b>Quản trị đơn vị tính </b>
                </div>

                <div class="row">
                    <div class="col-md-3 col-lg-3" style="font-weight: bold">
                        Mã :
                    </div>
                    <div class="col-md-9 col-lg-9">
                        <asp:Label ID="lblServiceID" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="row" style="padding-top: 5px;">
                    <div class="col-md-3 col-lg-3" style="font-weight: bold">
                        Tên :
                    </div>
                    <div class="col-md-9 col-lg-9">
                        <asp:TextBox ID="txtServiceName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px">
                            <div class="col-md-3 col-lg-3" style="font-weight: bold">
                                Trạng thái :
                            </div>
                            <div class="col-md-9 col-lg-9">
                                <asp:DropDownList ID="ddlTrangThai" runat="server" AutoPostBack="true" CssClass="form-control" Height="30px"
                                    Width="350px" OnSelectedIndexChanged="ddlTrangThai_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="Hoạt động"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Không hoạt động"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                <div class="row" style="padding-top: 5px;">
                    <div class="col-md-3 col-lg-3" style="font-weight: bold">
                    </div>
                    <div class="col-md-9 col-lg-9">
                        <asp:Button ID="btnAddservice" runat="server" OnClick="btnAddservice_Click" Width="100px" CssClass="btn btn-primary"
                            Text="Thêm mới" />
                        &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdateService" runat="server" Width="100px" CssClass="btn btn-success"
                    OnClick="btnUpdateService_Click" Text="Cập nhật" />
                        &nbsp;&nbsp;&nbsp;
             <%--   <asp:Button ID="btnDeleteService" runat="server" Width="100px" CssClass="btn btn-danger"
                    OnClick="btnDeleteService_Click" Text="Xóa " OnClientClick="if ( !confirm('Bạn có chắc muốn xóa không ?')) return false;" />
                    </div>--%>
                </div>
                <div class="row" >
                    <br />
                    <asp:GridView ID="grv" runat="server" AllowPaging="True" Width="100%" CssClass="table"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" OnSelectedIndexChanged="grv_SelectedIndexChanged"
                        OnPageIndexChanging="grv_PageIndexChanging"
                        OnRowDataBound="grv_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:ButtonField CommandName="select" Text="Button" Visible="False" />
                            <asp:BoundField DataField="Id" HeaderText="Mã">                               
                            </asp:BoundField>
                            <asp:BoundField DataField="DonViTinh" HeaderText="Tên">                               
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
            <%-- </ContentTemplate>
      </asp:UpdatePanel>--%>

            <%-- <div id="footer" align="center">            
          <div id="footer1">
                <div id="footer11">
                    <uc3:footer ID="f1" runat="server" />
                </div>
          </div>
        </div>--%>
        </div>

    </div>

</asp:Content>
