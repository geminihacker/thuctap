using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
namespace MyNews
{
    public partial class SiteAdmin : System.Web.UI.MasterPage
    {
        Class1 db = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
           
          
        }
        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox2.Checked = true;
        }
        public void BindInfo(string userid)
        {
           
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["ID"] = null;
            Session["DisplayName"] = null;
            Session["Menu"] = null;
            Response.Redirect("/dangnhap");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }
    }
}