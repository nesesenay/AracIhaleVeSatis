using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.DBKurumsalAracEkle
{
    public class DBAracOzellikleriVM
    {
        public DBAracDetayEkleVM AracDetaylari { get; set; }
        public DBAracEkleVM AracBilgileri { get; set; }
        public DBKurumsalKullaniciAracDetayEkle KurumsalAracBilgileri { get; set; }
    }
}