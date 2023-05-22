using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri
{
    public class BelirlenenKomisyonVM
    {
        public int BelirlenenKomisyonID { get; set; }
        public decimal KomisyonUcret { get; set; }
        public decimal AltLimit { get; set; }
        public decimal UstLimit { get; set; }
        public int ParaBirimID { get; set; }
    }
}