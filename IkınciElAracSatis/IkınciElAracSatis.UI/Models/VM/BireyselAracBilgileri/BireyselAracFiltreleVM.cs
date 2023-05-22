using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri
{
    public class BireyselAracFiltreleVM
    {
        public int Marka { get; set; }
        public int Model { get; set; }
        public int BireyselAracStatu { get; set; }
        public int AracID { get; set; }

        public List<SelectListItem> Modeller { get; set; }
        public List<SelectListItem> Markalar { get; set; }
        public List<SelectListItem> BireyselAracStatuleri { get; set; }
    }
}