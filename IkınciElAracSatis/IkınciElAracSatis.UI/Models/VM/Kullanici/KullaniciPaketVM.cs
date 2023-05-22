using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.Kullanici
{
    public class KullaniciPaketVM
    {
        public PaketVM KullaniciPaketleri { get; set; }
        public KurumsalKullaniciVM KurumsalKullanici { get; set; }
    }
}