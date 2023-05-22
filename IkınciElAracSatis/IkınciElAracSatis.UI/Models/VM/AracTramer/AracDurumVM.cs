using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.AracTramer
{
    public class AracDurumVM
    {
        public int AracID { get; set; }
        public int AracParcaID { get; set; }
        public int AracParcaDurumID { get; set; }
    }
}