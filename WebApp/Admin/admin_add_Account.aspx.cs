using MyNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebApp;
using WebApp.DTO;
using WebApp.DAL;
using WebApp.BUS;
namespace WebApp.Admin
{
    public partial class admin_add_Account : System.Web.UI.Page
    {
        Class1 db = new Class1();
        public void hienthi()
        {
            String sql = "SELECT Account.*, don_vi.ten_donvi,case gioitinh when 'False' then N'Nữ' when 'True' then N'Nam' end as gioitinhA FROM Account,don_vi Where Account.id_donvi=don_vi.id_donvi";
            DataView dv = new DataView(db.bindDataTable(sql));
            example.DataSource = dv;
            example.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}