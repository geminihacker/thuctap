using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp;
using WebApp.DTO;
using WebApp.DAL;
using System.Data;
using System.Data.SqlClient;
using MyNews;
namespace WebApp.BUS
{
    
    public class BUS_LTB
    {
        DAL_LTB dal_ltb = new DAL_LTB();
        
        public bool Query(string name,DTO_LTB tb)
        {
            return dal_ltb.ExcuteQuery_LTB(name,tb);
        }

        public bool Delete(string name,string ma)
        {
            return dal_ltb.Delete_LTB(name, ma);
        }
    }
}