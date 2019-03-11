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

namespace MyNews
{
    public partial class admin_menu : System.Web.UI.UserControl
    {
        Class1 db = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("/dangnhap");
            }
            else
            {
                
                BindMenu(Session["ID"].ToString());

                //if (!IsPostBack)
                //{
                //    lblHoTen.Text = Session["DisplayName"].ToString();
                //    BindInfo(Session["ID"].ToString());
                //}

                // Lấy đường dẫn hiện tại
                //string link =  Request.UrlReferrer.PathAndQuery;
                
                // Check menu được phân quyền
                if(Session["Menu"] != null)
                {
                    string link = Request.Url.AbsolutePath;
                    bool check = false;

                    if (link.Substring(0, 8) == "/tinnhan" || link.Substring(0, 12) == "/nhomtinnhan" || link == "/admin_banhangs.aspx" || link == "/admin_main.aspx" || link == "/dh_tracuu.aspx")
                    {
                        check = true;
                    }
                    else
                    {
                        DataTable dt = Session["Menu"] as DataTable;
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string link1 = dt.Rows[i]["link"].ToString();
                                if (link1 == link)
                                {
                                    check = true;
                                    break;
                                }
                            }
                        }
                    }
                    if(check == false)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "myalert", "alert('Bạn không có quyền truy cập địa chỉ này !');", true);
                        Response.Redirect("/dangnhap");
                    }
                }
                else
                {
                    Response.Redirect("/dangnhap");
                }
            }
           
        }
        
        public void BindMenu(string userid)
        {
            //rptCha.DataSource = db.ExecuteSelectProcedure("SelectMenu", new object[] {  "0",  userid });
            //rptCha.DataBind();
        }

        protected void rptCha_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string pid = DataBinder.Eval(e.Item.DataItem, "id").ToString(); 
                //Repeater rptN2 = (Repeater)e.Item.FindControl("rpt");
              
            }
        }

       
        
      
    }
}