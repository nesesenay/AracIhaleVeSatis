using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.KullaniciRol
{
    public class SecilenAracVM
    {
        public int AracID { get; set; }
        public bool GrantiliMi { get; set; }
        public DateTime KaydedilenTarih { get; set; } = DateTime.Now;
        public int ModelID { get; set; }
        public int MarkaID { get; set; }
        public int PlakaID { get; set; }
    }
}