using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models;
using IkınciElAracSatis.UI.Models.VM.Admin;
using IkınciElAracSatis.UI.Models.VM.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.DAL.Kullanici
{
    public class TumKullanicilarVM
    {
        public List<BireyselKullaniciVM> BireyselKullanicilar { get; set; }
        public List<KurumsalKullaniciVM> KurumsalKullanicilar { get; set; }
        public List<AdminProfilVM> AdminKullanicilar { get; set; }
    }
}