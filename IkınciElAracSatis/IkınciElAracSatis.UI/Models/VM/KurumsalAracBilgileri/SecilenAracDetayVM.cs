using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri
{
    public class SecilenAracDetayVM
    {
        public int AracID { get; set; }
        public string Aciklama { get; set; }
        public int GovdeTipiID { get; set; }
        public decimal KmBilgisi { get; set; }
        public int RenkID { get; set; }
        public string MotorGucu { get; set; }
        public string MotorHacmi { get; set; }
        public int VersiyonID { get; set; }
        public int VitesTipiID { get; set; }
        public int YakitTipiID { get; set; }
        public string Yil { get; set; }
        public int DonanimID { get; set; }
    }
}