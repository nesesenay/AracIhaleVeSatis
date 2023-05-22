using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri
{
    public class KomisyonUcretVM
    {
        public int AracID { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int BelirlenenKomisyonID { get; set; }
        public decimal AracUcret { get; set; }
    }
}