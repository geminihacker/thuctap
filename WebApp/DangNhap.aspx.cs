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
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace MyNews.Admin
{
    public partial class DangNhap : System.Web.UI.Page
    {
        string username = "";
        string pass = "";
        Class1 db = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["username"] = null;
            Session["ID"] = null;
            Session["Menu"] = null;
           
        }

        protected void btndangnhap_Click(object sender, EventArgs e)
        {
                username = txtuser.Text.Trim().Replace("'", "''").Replace("or", ".").Replace(">", ".").Replace("<", ".").Replace("=", ".");
                pass = txtpass.Text.Trim().Replace("'", "''").Replace("or", ".").Replace(">", ".").Replace("<", ".").Replace("=", ".");
                string pass1 = db.MD5Hash(pass);
                string sql = "select * from Account where name_user = '" + username + "' and  matkhau = '" + pass1 + "'";
                DataTable dt = db.bindDataTable(sql);

                //DataTable dt = db.ExecuteSelectProcedure("SelectAdmin", new object[] { username, pass1 });
                if (string.IsNullOrEmpty(username))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Chưa nhập tên đăng nhập !');", true);

                }
                else if (string.IsNullOrEmpty(pass))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Chưa nhập mật khẩu !');", true);
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        Session["username"] = username;
                        Response.Redirect("~/Trangchu.aspx");
                    }
                    else
                    {

                        lblThongBao.Text = "Đăng nhập không thành công !";
                        txtuser.Focus();
                        return;
                    }
                }
        }

    }
}
