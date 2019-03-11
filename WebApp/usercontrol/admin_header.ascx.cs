using MyNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.usercontrol
{
    public partial class admin_header : System.Web.UI.UserControl
    {
        Class1 db = new Class1();
        String user = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                user = Session["username"].ToString();
                string sql = "select Account.*,don_vi.ten_donvi from Account,don_vi where Account.id_donvi=don_vi.id_donvi and name_user='" + user + "'";
                String name = "";
                String huyen = "";
                String avatar = "";
                foreach (DataRow user in db.bindDataTable(sql).Rows)
                {
                    name = user["tenhienthi"].ToString();
                    huyen = user["ten_donvi"].ToString();
                    avatar = user["anhdaidien"].ToString();
                }
                user_text.Text = name;
                Image1.ImageUrl = avatar;
            }
            else
            {
                Response.Redirect("~/DangNhap.aspx");
            }
        }
    }
}