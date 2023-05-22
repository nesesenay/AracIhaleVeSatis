using IkınciElAracSatis.UI.Models.VM.KullaniciRol;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracFiltrele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri
{
    public class KurumsalAracGuncelleVM
    {
        public SecilenAracVM Arac { get; set; }
        public SecilenKurumsalAracVM KurumsalArac { get; set; }
        public SecilenAracDetayVM AracDetay { get; set; }

    }
}