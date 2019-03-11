using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace MyNews
{
    public  class Class1
    {
        public static string conn = WebConfigurationManager.ConnectionStrings["ConnectionToMyNews"].ConnectionString;
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter adapter;
        public SqlDataReader reader;
        public DataTable dt;
        public SqlDataReader sdr;
        public void ConnectionString()
        {
            con = new SqlConnection(conn);
            con.Open();
        }
        public void close()
        {
            con.Close();
            con.Dispose();
        }
       
        public int ExecuteQuery(string sql)
        {
            ConnectionString();
            SqlCommand cmd = new SqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            close();
            return i;
        }
        public DataTable bindDataTable(string sql)
        {
            ConnectionString();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            close();
            return dt;
        }

        //MD5
        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

       
    }
}
