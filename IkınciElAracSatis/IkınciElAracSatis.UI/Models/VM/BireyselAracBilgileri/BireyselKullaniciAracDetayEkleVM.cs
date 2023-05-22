using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri
{
    public class BireyselKullaniciAracDetayEkleVM
    {
        public int BireyselAracStatuID { get; set; }

        public List<SelectListItem> AracStatuleri { get; set; }
    }
}