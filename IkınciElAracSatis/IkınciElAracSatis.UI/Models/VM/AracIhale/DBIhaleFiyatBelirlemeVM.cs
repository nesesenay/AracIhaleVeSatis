using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.AracIhale
{
    public class DBIhaleFiyatBelirlemeVM
    {
        public int AracID { get; set; }
        public decimal IhaleBaslangicFiyati { get; set; }
        public decimal MinimumAlimFiyati { get; set; }
        public int ParaBirimID { get; set; }

        public List<SelectListItem> Araclar { get; set; }
    }
}