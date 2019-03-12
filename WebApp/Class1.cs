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
        private static Class1 intance;

        public static Class1 Intance
        {
            get 
            {
                if(intance == null)
                {
                    intance = new Class1();
                }
                return Class1.intance; }
            private set { Class1.intance = value; }
        }
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

        public DataTable ExcuteQuerry(string querry, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(querry, connect);

                if (parameter != null)
                {
                    // toi uu lai chuoi parameteter khong con cac khoang trang

                    string[] listPara = querry.Split(' ');

                    int i = 0;
                    foreach (string item in listPara)
                    {
                        // Kiem tra chuoi co parameter hay khong 
                        // chuoi co dang stored procesudes
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connect.Close();
            }

            return data;
        }


        // Tra ra so dong duoc lay du lieu
        public int ExcuteNonQuerry(string querry, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                SqlCommand command = new SqlCommand();

                if (parameter != null)
                {
                    string[] listPara = querry.Split(' ');

                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connect.Close();

            }

            return data;
        }

        public object ExcuteScarla(string querry, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                SqlCommand command = new SqlCommand();

                if (parameter != null)
                {
                    string[] listPara = querry.Split(' ');

                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connect.Close();
            }

            return data;
        }

       
    }
}
