using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.UI.DAL.Kullanici;
using IkınciElAracSatis.UI.Models.VM.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Controllers
{
    public class PaketTanimlamaController : Controller
    {
        // GET: PaketTanimlama
        public ActionResult Index()
        {
            List<KurumsalKullaniciVM> kurumsalKullanicilar = new KullaniciDAL().KurumsalKullaniciGetir();

            return View(kurumsalKullanicilar);
        }

        [HttpGet]
        public ActionResult PaketTanimla(int id)
        {
            KurumsalKullaniciVM gelenKurumsalKullaniciBilgileri = new KullaniciDAL().IDBilgisineGoreKurumsalKullaniciGetir(id);
            var paketler = new KullaniciDAL().KullaniciPaketleriGetir();

            var kullaniciPaketleri = new PaketVM()
            {
                Paketler = paketler.Select(a => new SelectListItem()
                {
                    Text = a.PaketAdi,
                    Value = a.PaketID.ToString()
                }).ToList(),
            };

            var paketTanimlamalari = new KullaniciPaketVM
            {
                KullaniciPaketleri = kullaniciPaketleri,
                KurumsalKullanici = gelenKurumsalKullaniciBilgileri
            };

            return View(paketTanimlamalari);
        }

        [HttpPost]

        public ActionResult PaketTanimla(KullaniciPaketVM vm)
        {
            IkinciElAracSatisContext db = new IkinciElAracSatisContext();

            foreach (var item in db.PaketTanimlamalari)
            {

                if (vm.KurumsalKullanici.KurumsalKullaniciID == item.KullaniciID)
                {
                    new KullaniciDAL().KurumsalKullaniciPaketGuncelle(vm.KullaniciPaketleri, vm.KurumsalKullanici.KurumsalKullaniciID);
                }
                else
                {
                    new KullaniciDAL().KurumsalKullaniciPaketTanimla(vm);
                }
            }

           

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UyeDetay(int id)
        {
            KurumsalKullaniciVM gelenKurumsalKullaniciBilgileri = new KullaniciDAL().IDBilgisineGoreKurumsalKullaniciGetir(id);

            return View(gelenKurumsalKullaniciBilgileri);

        }

        [HttpPost]
        public ActionResult UyeDetay(KurumsalKullaniciVM vm)
        {
            var onaylananKullanici = new KullaniciDAL().KurumsalKullaniciOnay(vm);

         

            return RedirectToAction("UyeDetay");

        }
    }
}