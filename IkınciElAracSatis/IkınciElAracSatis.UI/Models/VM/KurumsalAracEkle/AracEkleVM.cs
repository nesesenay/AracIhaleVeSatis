using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM
{
    public class AracEkleVM
    {
        public int AracNo { get; set; }
        public bool GarantiliMi { get; set; }
        public int PlakaID { get; set; }
        public int ModelID { get; set; }
        public int MarkaID { get; set; }
        public int AdminID { get; set; }
        public DateTime KaydedilenTarih { get; set; }

        public List<SelectListItem> Plakalar { get; set; }
        public List<SelectListItem> Modeller { get; set; }
        public List<SelectListItem> Markalar { get; set; }
    }
}