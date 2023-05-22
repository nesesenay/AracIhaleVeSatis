using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri
{
    public class BireyselAracListeleVM
    {
        public List<BireyselAracGetirVM> BireyselAraclar { get; set; }
        public BireyselAracFiltreleVM BireyselAracFiltreleri { get; set; }
    }
}