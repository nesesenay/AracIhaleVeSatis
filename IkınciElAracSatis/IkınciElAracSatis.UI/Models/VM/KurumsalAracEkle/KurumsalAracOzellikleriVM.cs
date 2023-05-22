using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM
{
    public class KurumsalAracOzellikleriVM
    {
        public AracDetayEkleVM AracDetaylari { get; set; }
        public AracEkleVM Araclar { get; set; }
        public KurumsalKullaniciAracDetayEkleVM KurumsalKullaniciAracDetaylari { get; set; }
    }
}