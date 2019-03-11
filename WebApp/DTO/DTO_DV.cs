using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.DTO
{
    public class DTO_DV
    {
        private string _ma_dv;
        private string _ten_dv;
        private string _diachi;
        private string _mota;

        public string MaDV
        {
            get { return _ma_dv; }
            set { _ma_dv = value; }
        }
        public string TenDV
        {
            get { return _ten_dv; }
            set { _ten_dv = value; }
        }
        public string DiaChi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }
        public string MoTa
        {
            get { return _mota; }
            set { _mota = value; }
        }

        public DTO_DV(String pma,string pten,string pdc,string pmota)
        {
            this._ma_dv = pma;
            this._ten_dv = pten;
            this._diachi = pdc;
            this._mota = pmota;

        }
    }
}