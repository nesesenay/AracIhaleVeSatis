using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri
{
    public class SecilenKurumsalAracVM
    {
        public int ParaBirimID { get; set; }
        public decimal Fiyat { get; set; }
        public int AracStatuID { get; set; }
        public int SirketID { get; set; }
    }
}