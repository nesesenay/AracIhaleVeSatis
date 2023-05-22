using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM
{
    public class DBKurumsalKullaniciAracDetayEkle
    {
        public int SirketID { get; set; }
        public decimal Fiyat { get; set; }
        public int ParaBirimID { get; set; }
        public int AracStatuID { get; set; }
        public int AracID { get; set; }
    }
}