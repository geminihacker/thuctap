using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace MyNews
{
    public partial class admin_donvitinh : System.Web.UI.Page
    {
        Class1 db = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////txtSort.Text = "1";
                //if (Session["ID"] != null)
                //{
                    BindGrv();
                //}
                //else
                //{
                //    Response.Redirect("/dangnhap");
                //}
            }

        }
        public void BindGrv()
        {
            //string sql = "select * from service";
            //grv.DataSource = db.ExecuteSelectProcedure("_Select_DonViTinh", new object[] { ddlTrangThai.SelectedValue });
            grv.DataBind();
        }
        

        protected void grv_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectrow = grv.SelectedRow;
            lblServiceID.Text = Server.HtmlDecode(selectrow.Cells[1].Text);
            txtServiceName.Text = Server.HtmlDecode(selectrow.Cells[2].Text);

        }

        protected void grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv.PageIndex = e.NewPageIndex;
            BindGrv();
        }

        protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "select$" + e.Row.RowIndex);
                for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                    e.Row.Cells[columnIndex].Attributes["onclick"] = _jsSingle;

                }
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in grv.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "select$" + row.RowIndex);
                }
            }
            base.Render(writer);
        }

        protected void btnAddservice_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServiceName.Text.Trim() != "")
                {
                    //db.ExecuteCRUDProcedure("_Insert_DonViTinh", new object[] { txtServiceName.Text});
                    BindGrv();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Thêm mới thành công !');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Chưa nhập tên !');", true);
                }
              
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnUpdateService_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServiceName.Text.Trim() != "")
                {
                    //db.ExecuteCRUDProcedure("_Update_DonViTinh", new object[] { lblServiceID.Text ,txtServiceName.Text, ddlTrangThai.SelectedValue });
                    BindGrv();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Cập nhật thành công !');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Chưa nhập tên !');", true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnDeleteService_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblServiceID.Text != "")
                {
                    //db.ExecuteCRUDProcedure("_Delete_DonViTinh", new object[] { lblServiceID.Text});
                    BindGrv();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Xóa thành công !');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Chưa chọn bản ghi !');", true);
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrv();
        }
     
    }
}
