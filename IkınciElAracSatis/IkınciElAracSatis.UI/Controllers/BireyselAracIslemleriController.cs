using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.DAL.Admin;
using IkınciElAracSatis.UI.DAL.BireyselAracIslemleri;
using IkınciElAracSatis.UI.DAL.DBBireyselAeacGuncelle;
using IkınciElAracSatis.UI.DAL.Kullanici;
using IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Controllers
{
    public class BireyselAracIslemleriController : Controller
    {
        // GET: BireyselAracIslemleri
        [Authorize]
        public ActionResult Index()
        {
            BireyselKullaniciAracListelemDAL bireyselAracListeleme = new BireyselKullaniciAracListelemDAL();
            var bireyselAraclar = bireyselAracListeleme.BireyselAraclariGetir();

            return View(bireyselAraclar);
        }

        [HttpGet]
        public ActionResult Detay(int? id)
        {
            if (id != null)
            {
                Session["AracID"] = id;
            }

            int aracID = (int)Session["AracID"];

            BireyselKullaniciAracListelemDAL bireyselAracListeleme = new BireyselKullaniciAracListelemDAL();
            var guncellenecekAracBilgisi = bireyselAracListeleme.GuncellenecekAracBilgisiGetir(aracID);

            EklenenBireyselAracBilgileriDAL eklenenAracBilgileri = new EklenenBireyselAracBilgileriDAL();
            var aracDetaylari = eklenenAracBilgileri.EklenenBireyselKullaniciAracBilgileriniGetir();


            var guncellenecekBilgiler = new GuncellenecekBireyselAracVM {
               Item1 = guncellenecekAracBilgisi,
               Item2 = aracDetaylari
            };

            return View(guncellenecekBilgiler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detay(GuncellenecekBireyselAracVM vm)
        {
            var model1 = vm.Item2;

            if (model1 != null)
            {
                int aracID = (int)Session["AracID"];

                new DBBireyselAracGuncelleDAL().AracBilgileriniGuncelle(model1, aracID);


                return RedirectToAction("Index");

            }

            return RedirectToAction("Detay");
        }

        [HttpGet]
        public ActionResult BireyselAracTarihce()
        {
            int id = (int)Session["AracID"];

            var gelenBireyselAracTarihce = new BireyselAracDAL().BireyselAracTarihceGetir(id);

            return View(gelenBireyselAracTarihce);
        }
    }
}