using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp;
using MyNews;
using WebApp.DTO;
using System.Data.SqlClient;
using System.Data;

namespace WebApp.DAL
{
    public class DAL_DV:Class1
    {
        Class1 db = new Class1();

        public bool ExcuteQuery_DV(String name,DTO_DV dv)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conn);
                SqlCommand command = new SqlCommand(name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ma_donvi", dv.MaDV));
                command.Parameters.Add(new SqlParameter("@ten_donvi", dv.TenDV));
                command.Parameters.Add(new SqlParameter("@dia_chi", dv.DiaChi));
                command.Parameters.Add(new SqlParameter("@mo_ta",dv.MoTa));
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

        public bool Delete_dv(String name, string ma)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conn);
                SqlCommand command = new SqlCommand(name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ma_donvi", ma));
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