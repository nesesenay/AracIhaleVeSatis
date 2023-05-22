using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri
{
    public class AracTarihceVM
    {
        public int AracID { get; set; }
        public string Statu { get; set; }
        public DateTime DegistirilmeTarihi { get; set; } = DateTime.Now;
        public int AracStatuID { get; set; }
    }
}