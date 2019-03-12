using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.DAL;

namespace WebApp.BUS
{
    public class BUS_NT
    {
        private static BUS_NT intance;

        public static BUS_NT Intance
        {
            get
            {
                if(intance == null)
                {
                    intance = new BUS_NT();
                }
                return BUS_NT.intance; 
            }
            private set { BUS_NT.intance = value; }
        }

        public bool DeleteData(string ma)
        {
            return DAL_NT.Intance.CheckDelete(ma);
        }

        public bool CheckUpdate(string id, string name, string address, string status, string idoffce)
        {
            return DAL_NT.Intance.UpdateNT(id, name, address, status, idoffce);
        }

        public bool CheckInsert(string id, string name, string address, string status, string idoffce)
        {
            return DAL_NT.Intance.InsertNT(id, name, address, status, idoffce);
        }
    }
}