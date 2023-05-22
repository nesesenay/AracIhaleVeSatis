using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using IkınciElAracSatis.UI.Models.VM.KullaniciRol;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri
{
    public class BireyselAracGuncelleVM
    {
        public SecilenAracVM Arac { get; set; }
        public SecilenBireyselAracVM BireyselArac { get; set; }
        public SecilenAracDetayVM AracDetay { get; set; }
        public decimal TekliFiyati { get; set; }
        public decimal OnDegerlemeTutari { get; set; }
        public string AracSahibininAdi { get; set; }

    }
}