using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM
{
    public class KurumsalKullaniciAracDetayEkleVM
    {
        public decimal Fiyat { get; set; }
        public int ParaBirimID { get; set; }
        public int AracStatuID { get; set; }
        public int AracID { get; set; }
        public int SirketID { get; set; }


        public List<SelectListItem> Sirketler { get; set; }
        public List<SelectListItem> ParaBirimleri { get; set; }
        public List<SelectListItem> AracStatuleri { get; set; }
    }
}