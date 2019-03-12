using MyNews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyNews;
using WebApp.BUS;
namespace WebApp
{
    public partial class admin_ds_nhatram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void example_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "chinhsua")
            {
                string ma = e.CommandArgument.ToString();
                CheckUpdate(ma);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAddEdit();", true);
            }
            else if (e.CommandName == "xoa")
            {
                string ma = e.CommandArgument.ToString();
                CheckDelete(ma);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAddDelete();", true);
            }
        }

        private void CheckDelete(string ma)
        {
            string querry = string.Format("SELECT * FROM dbo.nha_tram WHERE ma_tran = N'{0}'", ma);
            foreach (DataRow row in Class1.Intance.ExcuteQuerry(querry).Rows)
            {
                txt_ten.Text = row["ten_tram"].ToString();
                txt_delete.Text = row["ma_tran"].ToString();
            }
        }

        void Delete()
        {
            string matram = txt_delete.Text;
            if (BUS_NT.Intance.DeleteData(matram))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Xóa trạm thành công !!!', 'success');", true);
                LoadData();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Xóa trạm thất bại !!!', 'success');", true);

            }
        }

        void Update()
        {
            string matram = txt_matram_edit.Text;
            string tentram = txt_tentram_edit.Text;
            string diachi = txt_diachi_edit.Text;
            string status = txt_mota_edit.Text;
            string iddv = cbx_donvi_edit.SelectedValue.ToString();

            if (BUS_NT.Intance.CheckUpdate(matram, tentram, diachi, status, iddv))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Cập nhật đơn vị thành công !!!', 'success');", true);
                LoadData();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Cập nhật đơn vị thất bại !!!', 'error');", true);
            }
        }
        void Insert()
        {
            string matram = txt_add_matram.Text;
            string tentram = txt_add_tentram.Text;
            string diachi = txt_add_diachi.Text;
            string status = txt_add_mota.Text;
            string iddv = cbx_add_dv.SelectedValue.ToString();
       
                string sql = "Select ma_tran from don_vi where ma_tran='" + txt_add_matram.Text + "'";
                string ma = "";
                foreach (DataRow dt in Class1.Intance.ExcuteQuerry(sql).Rows)
                {
                    ma = dt["ma_tran"].ToString();
                }
                if (ma == txt_add_matram.Text)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Mã đơn vị đã tồn tại !!!', 'error');", true);
                }
                else
                {

                    if (DAL.DAL_NT.Intance.InsertNT(matram, tentram, diachi, status, iddv))
                    {

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Thêm đơn vị thành công !!!', 'success');", true);
                        LoadData();

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "$.notify('Thêm đơn vị thất bại !!!', 'error');", true);
                    }
                }
            

      

        }
        private void CheckUpdate(string ma)
        {
            string querry = string.Format("SELECT * FROM dbo.nha_tram WHERE ma_tran = N'{0}'", ma);
            foreach (DataRow row in Class1.Intance.ExcuteQuerry(querry).Rows)
            {
                string donvi = cbx_donvi_edit.SelectedValue.ToString();
                txt_matram_edit.Text = row["ma_tran"].ToString();
                txt_tentram_edit.Text = row["ten_tram"].ToString();
                txt_diachi_edit.Text = row["dia_chi"].ToString();
                txt_mota_edit.Text = row["mo_ta"].ToString();
                donvi = row["id_donvi"].ToString();

                cbx_donvi_edit.SelectedValue = (string)donvi.ToString();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Insert();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void LoadData()
        {
            string querry = "EXEC dbo.[_Slect_Tram_ByIDDV]";
            DataView view = new DataView(Class1.Intance.ExcuteQuerry(querry));
            example.DataSource = view;
            example.DataBind();

            LoadDataCombobox();
        }

        public void LoadDataCombobox()
        {
            string querry = "__Select_donvi";
            DataView view = new DataView(Class1.Intance.ExcuteQuerry(querry));

            cbx_add_dv.DataSource = view;

            cbx_add_dv.DataValueField = "ma_donvi";
            cbx_add_dv.DataTextField = "ten_donvi";
            cbx_add_dv.DataBind();

            cbx_donvi_edit.DataSource = view;

            cbx_donvi_edit.DataValueField = "ma_donvi";
            cbx_donvi_edit.DataTextField = "ten_donvi";
            cbx_donvi_edit.DataBind();
        }
    }
}