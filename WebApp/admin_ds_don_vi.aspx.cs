using MyNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.DTO;
using WebApp.DAL;
using WebApp.BUS;
using System.Text;

namespace WebApp
{
    public partial class admin_ds_don_vi : System.Web.UI.Page
    {
        Class1 db = new Class1();
        BUS_DV bus_dv = new BUS_DV();
        public void hienthi()
        {
            String sql = "SELECT * FROM don_vi";
            DataView dv = new DataView(db.bindDataTable(sql));
            example.DataSource = dv;
            example.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            hienthi();
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "Select ma_donvi from don_vi where ma_donvi='" + txt_madv.Text + "'";
                String ma = "";
                foreach(DataRow dt in db.bindDataTable(sql).Rows)
                {
                    ma = dt["ma_donvi"].ToString();
                }
                if (ma == txt_madv.Text)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Mã đơn vị đã tồn tại !!!', 'error');", true);                    
                }
                else
                {
                    DTO_DV dv = new DTO_DV(txt_madv.Text, txt_tendv.Text, txt_diachi.Text, txt_mota.Text);
                    if (bus_dv.Query("_Insert_donvi", dv))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Thêm đơn vị thành công !!!', 'success');", true);
                        hienthi();
                        clearAll();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Thêm đơn vị thất bại !!!', 'error');", true);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        
        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            String ma = txt_delete.Text;
            
            if (bus_dv.Delete("_Delete_Donvi", ma))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Xóa đơn vị thành công !!!', 'success');", true);
                hienthi();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Xóa đơn vị thất bại !!!', 'error');", true);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                DTO_DV dv = new DTO_DV(txt_madv_edit.Text, txt_tendv_edit.Text, txt_diachi_edit.Text, txt_mota_edit.Text);
                if (bus_dv.Query("_Update_donvi", dv))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Cập nhật đơn vị thành công !!!', 'success');", true);
                    hienthi();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Cập nhật đơn vị thất bại !!!', 'error');", true);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void example_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "chinhsua")
            {
                string ma = e.CommandArgument.ToString();
                BindInfo(ma);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAddEdit();", true);
            }
            else if(e.CommandName == "xoa")
            {
                string ma = e.CommandArgument.ToString();
                GetData(ma);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAddDelete();", true);
            }
        }

        public void BindInfo(string ma)
        {
            String sql = "Select * from don_vi where ma_donvi='" + ma.ToString() +"'";
            foreach(DataRow dt in db.bindDataTable(sql).Rows)
            {
                txt_madv_edit.Text= dt["ma_donvi"].ToString();
                txt_tendv_edit.Text = dt["ten_donvi"].ToString();
                txt_diachi_edit.Text = dt["dia_chi"].ToString();
                txt_mota_edit.Text = dt["mo_ta"].ToString();
            }
        }

        public void GetData(String ma)
        {
            String sql = "Select * from don_vi where ma_donvi='" + ma.ToString() + "'";
            foreach (DataRow dt in db.bindDataTable(sql).Rows)
            {
                txt_ten.Text = dt["ten_donvi"].ToString();
                txt_delete.Text = dt["ma_donvi"].ToString();
            }
        }

        public void clearAll()
        {
            txt_madv.Text = "";
            txt_tendv.Text = "";
            txt_diachi.Text = "";
            txt_mota.Text = "";
        }
    }
}