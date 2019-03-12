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
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class admin_ds_don_vi : System.Web.UI.Page
    {
        Class1 db = new Class1();
        BUS_DV bus_dv = new BUS_DV();
        public void hienthi()
        {
            LoadSort();
            string sql = "SELECT * FROM don_vi";
            DataView dv = new DataView(db.bindDataTable(sql));
            example.DataSource = dv;
            example.DataBind();


        }

        public void SearchMenu()
        {
            string ma = txt_search.Text;
            string cbx = SelectItem.SelectedValue;
            string querry = string.Format("SELECT * FROM dbo.don_vi WHERE {0} like N'%{1}%'",cbx,ma);
            DataView dv = new DataView(db.bindDataTable(querry));
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
                string sql = "Select ma_donvi from don_vi where ma_donvi='" + txt_madv.Text + "'";
                string ma = "";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchMenu();
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        protected void example_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void example_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["TaskTable"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                example.DataSource = Session["TaskTable"];
                example.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.x
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        private void LoadSort()
        {
            if (!Page.IsPostBack)
            {

                // Create a new table.
                DataTable taskTable = new DataTable("TaskList");

                // Create the columns.
                taskTable.Columns.Add("ma_donvi", typeof(string));
                taskTable.Columns.Add("ten_donvi", typeof(string));
                taskTable.Columns.Add("dia_chi", typeof(string));
                taskTable.Columns.Add("mo_ta", typeof(string));
                string sql = "SELECT * FROM don_vi";
                //Add data to the new table.
                foreach (DataRow row in Class1.Intance.ExcuteQuerry(sql).Rows)
                {
                    DataRow tableRow = taskTable.NewRow();
                    tableRow["ma_donvi"] = row["ma_donvi"].ToString();
                    tableRow["ten_donvi"] = row["ten_donvi"].ToString();
                    tableRow["dia_chi"] = row["dia_chi"].ToString();
                    tableRow["mo_ta"] = row["mo_ta"].ToString();                       
                    taskTable.Rows.Add(tableRow);
                }

                //Persist the table in the Session object.
                Session["TaskTable"] = taskTable;

                //Bind the GridView control to the data source.
                example.DataSource = Session["TaskTable"];
                example.DataBind();

            }
        }
    }
}