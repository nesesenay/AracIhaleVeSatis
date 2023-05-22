using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri
{
    public class NoterUcretVM
    {
        public int AracID { get; set; }
        public decimal Ucret { get; set; } = 932;
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int ParaBirimID { get; set; } = 1;
    }
}