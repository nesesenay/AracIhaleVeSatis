using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM
{
    public class AracFiltreleVM
    {
        public int Marka { get; set; }
        public int Model { get; set; }
        public int Rol { get; set; }
        public int AracStatu { get; set; }
        public int AracID { get; set; }

        public List<SelectListItem> MusteriRolleri { get; set; }
        public List<SelectListItem> Modeller { get; set; }
        public List<SelectListItem> Markalar { get; set; }
        public List<SelectListItem> AracStatuleri { get; set; }

    }
}