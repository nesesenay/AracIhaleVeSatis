using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri
{
    public class TeklifFiyatiUcretVM
    {
        public int AracID { get; set; }
        public decimal Ucret { get; set; }
        public int ParaBirimiID { get; set; } = 1;
        public int AracUcretTipID { get; set; } = 1;
    }
}