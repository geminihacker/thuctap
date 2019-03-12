using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.DTO
{
    public class DTO_NT
    {
        private static DTO_NT intance;

        public static DTO_NT Intance
        {
            get
            { 
                if(intance == null)
                {
                    intance = new DTO_NT();
                }
                return DTO_NT.intance; 
            }
            private set { DTO_NT.intance = value; }
        }

        #region object
        private string matram;
        private string tentram;
        private string diachi;
        private string mota;
        private int idDonvi;
        #endregion
        #region propyties
        public int IdDonvi
        {
            get { return idDonvi; }
            set { idDonvi = value; }
        }

        public string Mota
        {
            get { return mota; }
            set { mota = value; }
        }

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string Tentram
        {
            get { return tentram; }
            set { tentram = value; }
        }

        public string Matram
        {
            get { return matram; }
            set { matram = value; }
        }
        #endregion

        
    }
}