using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracIhale
{
    public class IhaleDetayVM
    {
        public List<AracIhaleListeleVM> AracIhaleListesi { get; set; }
        public IhaleListeleVM IhaleBilgisi { get; set; }
    }
}