using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM
{
    public class AracDetayEkleVM
    {
        public int GovdeTipiID { get; set; }
        public string Yil { get; set; }
        public int YakitTipiID { get; set; }
        public int VitesTipiID { get; set; }
        public int VersiyonID { get; set; }
        public int FotoID { get; set; }
        public decimal KmBilgisi { get; set; }
        public int RenkID { get; set; }
        public int DonanimID { get; set; }
        public string Aciklama { get; set; }
        public string MotorGucu { get; set; }
        public string MotorHacmi { get; set; }
        public int AracID { get; set; }


        public List<SelectListItem> Donanimlar { get; set; }
        public List<SelectListItem> GovdeTipleri { get; set; }
        public List<SelectListItem> Renkler { get; set; }
        public List<SelectListItem> Versiyonlar { get; set; }
        public List<SelectListItem> VitesTipleri { get; set; }
        public List<SelectListItem> YakitTipleri { get; set; }
        public List<SelectListItem> Fotolar { get; set; }

    }

}