using IkınciElAracSatis.DAL.KullaniciGirisi;
using IkınciElAracSatis.UI.DAL.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Controllers
{
    public class KullaniciListelemeController : Controller
    {
        // GET: KullaniciListeleme
        public ActionResult Index()
        {
            var adminKullanicilar = new IkınciElAracSatis.DAL.KullaniciGirisi.ProfilBilgileriDAL().AdminKullanicilariGetir();
            var bireyselKullanicilar = new DAL.Kullanici.KullaniciDAL().BireyselKullaniciGetir();
            var kurumsalKullanicilar = new DAL.Kullanici.KullaniciDAL().KurumsalKullaniciGetir();

            var tumKullanicilar = new TumKullanicilarVM
            {
                 AdminKullanicilar = adminKullanicilar,
                 BireyselKullanicilar = bireyselKullanicilar,
                 KurumsalKullanicilar  = kurumsalKullanicilar
            };

            return View(tumKullanicilar);
        }
    }
}