using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracTramer
{
    public class AracTramerKaydiVM
    {
        public AracTramerVM AracTramer { get; set; }
        public List<AracDurumVM> AracDurum { get; set; }
    }
}