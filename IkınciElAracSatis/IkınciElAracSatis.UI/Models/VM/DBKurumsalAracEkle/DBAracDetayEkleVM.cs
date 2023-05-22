using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM
{
    public class DBAracDetayEkleVM
    {
        public int GovdeTipiID { get; set; }
        public string Yil { get; set; }
        public int YakitTipiID { get; set; }
        public int VitesTipiID { get; set; }
        public int VersiyonID { get; set; }
        public decimal KmBilgisi { get; set; }
        public int RenkID { get; set; }
        public int DonanimID { get; set; }
        public int FotoID { get; set; }
        public string Aciklama { get; set; }
        public string MotorGucu { get; set; }
        public string MotorHacmi { get; set; }
        public int AracID { get; set; }
    }
}