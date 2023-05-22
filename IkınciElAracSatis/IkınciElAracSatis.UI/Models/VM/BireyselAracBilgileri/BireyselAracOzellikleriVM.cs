using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri
{
    public class BireyselAracOzellikleriVM
    {
        public AracDetayEkleVM AracDetaylari { get; set; }
        public AracEkleVM Araclar { get; set; }
        public BireyselKullaniciAracDetayEkleVM BireyselKullaniciAracDetaylari { get; set; }
        public decimal TekliFiyati { get; set; }
        public decimal OnDegerlemeTutari { get; set; }
        public string AracSahibininAdi { get; set; }

    }
}