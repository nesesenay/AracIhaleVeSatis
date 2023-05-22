using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracIhale
{
    public class IhaleFiyatBelirlemeVM
    {
        public int AracID { get; set; }
        public decimal IhaleBaslangicFiyati { get; set; }
        public decimal MinimumAlimFiyati { get; set; }
        public int ParaBirimID { get; set; } = 1;
    }
}