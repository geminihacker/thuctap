using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp;
using MyNews;
using WebApp.DAL;
using WebApp.DTO;
namespace WebApp.BUS
{
    public class BUS_DV
    {
        DAL_DV dal_dv= new DAL_DV();
        
        public bool Query(String name,DTO_DV dv)
        {
            return dal_dv.ExcuteQuery_DV(name,dv);
        }

        public bool Delete(String name,String ma)
        {
            return dal_dv.Delete_dv(name, ma);
        }
    }
}