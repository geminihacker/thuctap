using MyNews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApp.DAL
{
    public class DAL_NT
    {
        private static DAL_NT intance;

        public static DAL_NT Intance
        {
            get 
            {
                if(intance == null)
                {
                    intance = new DAL_NT();
                }
                return DAL_NT.intance; 
            }
            set { DAL_NT.intance = value; }
        }

        public bool CheckDelete(string iddv)
        {
            string sql = string.Format("DELETE FROM dbo.nha_tram WHERE ma_tran = N'{0}'",iddv);
                
            int delete = Class1.Intance.ExcuteNonQuerry(sql);

            return delete > 0;
        }


        public bool InsertNT(string id, string name, string address, string status, string idoffce)
        {
            string sql = string.Format("INSERT dbo.nha_tram(ma_tran,ten_tram,dia_chi,mo_ta,id_donvi) VALUES (N'{0}',N'{1}',N'{2}',N'{3},{4})",id,name,address,status,idoffce);

            int insert = Class1.Intance.ExcuteNonQuerry(sql);

            return insert > 0;
        }

        public bool UpdateNT(string id, string name, string address, string status, string idoffce)
        {
            
            string sql = string.Format("UPDATE dbo.nha_tram SET ten_tram = N'{0}', dia_chi = N'{1}',mo_ta = N'{2}', id_donvi= '{3}' WHERE id_tran = N'{4}'",name,address,status,idoffce,id);

            int update = Class1.Intance.ExcuteNonQuerry(sql);

            return update > 0;
        }


             
    }
}