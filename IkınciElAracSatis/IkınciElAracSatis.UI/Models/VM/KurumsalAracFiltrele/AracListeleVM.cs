using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.KurumsalAracFiltrele
{
    public class AracListeleVM
    {
        public List<AracGetirVM> KurumsalAraclar { get; set; }
        public AracFiltreleVM AracFiltreleri { get; set; }
    }
}