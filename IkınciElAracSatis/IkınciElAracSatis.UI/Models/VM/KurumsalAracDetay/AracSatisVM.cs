using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.KurumsalAracDetay
{
    public class AracSatisVM
    {
        public int AracID { get; set; }
        public int SirketID { get; set; }
        public List<SelectListItem> Sirketler { get; set; }
    }
}