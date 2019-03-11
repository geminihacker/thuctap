using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp;
using System.Data;
using System.Data.SqlClient;
using WebApp.DTO;
using MyNews;

namespace WebApp.DAL
{
    
    public class DAL_LTB:Class1
    {
        Class1 db = new Class1();
        public bool ExcuteQuery_LTB(String name, DTO_LTB tb)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conn);
                SqlCommand command = new SqlCommand(name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ma_loaiTB", tb.MaLoaiTB));
                command.Parameters.Add(new SqlParameter("@ten_loaiTB", tb.TenLoaiTB));
                command.Parameters.Add(new SqlParameter("@trang_thai", tb.TrangThai));
                command.Parameters.Add(new SqlParameter("@mota_tb", tb.MoTa));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete_LTB(String name, string ma)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conn);
                SqlCommand command = new SqlCommand(name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ma_loaiTB", ma));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}