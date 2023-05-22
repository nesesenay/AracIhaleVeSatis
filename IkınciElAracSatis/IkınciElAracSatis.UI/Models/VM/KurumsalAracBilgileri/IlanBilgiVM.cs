using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri
{
    public class IlanBilgiVM
    {
        public int AracID { get; set; }
        public string IlanBasligi { get; set; }
        public string Aciklama { get; set; }
    }
}