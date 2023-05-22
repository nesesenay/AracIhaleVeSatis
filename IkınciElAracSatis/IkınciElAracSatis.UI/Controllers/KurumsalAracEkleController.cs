using IkınciElAracSatis.CORE.Context;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.DAL.Admin;
using IkınciElAracSatis.UI.DAL.AracTramerIslemleri;
using IkınciElAracSatis.UI.DAL.DBKurumsalAracEkleme;
using IkınciElAracSatis.UI.DAL.KullaniciAracEkleme;
using IkınciElAracSatis.UI.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.DAL.KurumsalKullaniciAracListele;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.AracTramer;
using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using IkınciElAracSatis.UI.Models.VM.DBKurumsalAracEkle;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracDetay;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace IkınciElAracSatis.UI.Controllers
{

    public class KurumsalAracEkleController : Controller
    {
        [Authorize]
        // GET: KurumsalAracEkle
        [HttpGet]
        public ActionResult Index()
        {

            KurumsalKullaniciAracEkleDAL aracEkle = new KurumsalKullaniciAracEkleDAL();
            KurumsalAracOzellikleriVM aracDetaylariVM = aracEkle.KurumsalKullaniciAracEkle();

            return View(aracDetaylariVM);
        }

        [HttpPost]

        public ActionResult Index(KurumsalAracOzellikleriVM vm, HttpPostedFileBase file)
        {
            int userId = (int)Session["UserId"];
           

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            string[] fotolar = new string[5];

            if (Request.Files != null && Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    file = Request.Files[i];
                    string image = $"fileName{i}";
                    if (file != null && file.ContentLength > 0)
                    {
                        var extention = Path.GetExtension(file.FileName);
                        fotolar[i] = string.Format($"{Guid.NewGuid()}{extention}");
                        // fileName'i ekranda göster veya dosyayı kaydet
                        var filePath = Path.Combine(Server.MapPath("~/Content/images"), fotolar[i]);
                        file.SaveAs(filePath);
                    }
                }
            }

                DBKurumsalKullaniciAracEkleDAL DBKurumsalKullaniciAracEkle = new DBKurumsalKullaniciAracEkleDAL();
                DBKurumsalKullaniciAracEkle.DBKurumsalKullaniciAracEkle(vm, userId, fotolar);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult AracGuncelle(int? id)
        {

            if (id != null)
            {
                Session["AracID"] = id;
            }

            int aracID = (int)Session["AracID"];
  
            KurumsalKullaniciAracFiltreleDAL aracFiltrele = new KurumsalKullaniciAracFiltreleDAL();
            var guncellenecekAracBilgisi =  aracFiltrele.GuncellenecekAracBilgisiGetir(aracID);

            KurumsalKullaniciAracEkleDAL aracEkle = new KurumsalKullaniciAracEkleDAL();
            KurumsalAracOzellikleriVM aracDetaylariVM = aracEkle.KurumsalKullaniciAracEkle();

            var guncellenecekBilgiler = new GuncellenecekBilgilerVM()
            {
                Item1 = guncellenecekAracBilgisi,
                Item2 = aracDetaylariVM
            };

            return View(guncellenecekBilgiler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AracGuncelle(GuncellenecekBilgilerVM vm)
        {
            var model1 = vm.Item2;

            if (model1 != null)
            {
                int aracID = (int)Session["AracID"];

                new DBKurumsalAracGuncelleDAL().AracBilgileriniGuncelle(model1, aracID);

                    return RedirectToAction("Index", "Home");
                
            }

            return RedirectToAction("AracGuncelle");
        }

        [HttpGet]
        public ActionResult IlanBilgisi()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IlanBilgisi(IlanBilgiVM vm)
        {

            int id = (int)Session["AracID"];

            vm.AracID = id;

            KurumsalAracBilgileriDAL kurumsalAracBilgileri = new KurumsalAracBilgileriDAL();

            var gelenIlanBilgileri = kurumsalAracBilgileri.AracIlanBilgileriniGetir();

            if (gelenIlanBilgileri.Where(a => a.AracID == id).FirstOrDefault() == null)
            {
                var eklenenIlanBilgisi = kurumsalAracBilgileri.AracIlanBilgisiEkle(vm);
                if (eklenenIlanBilgisi != null)
                {
                    ViewBag.Message = "İlan Bilgisi Başaraıyla Kaydedilmiştir";
                    return RedirectToAction("IlanBilgisi");
                }
            }
            else
            {
                ViewBag.Message = "Kayıtlı İlan Bilgisi bulunmaktadır.";         
            }

            return View();
        }

        [HttpGet]
        public ActionResult AracTarihce()
        {
            int id = (int)Session["AracID"];

            var gelenKurumsalAracTarihce =  new KurumsalAracDAL().KurumsalAracTarihceGetir(id);

            return View(gelenKurumsalAracTarihce);
        }

        public ActionResult NoterVeKomisyonToplami()
        {
            int id = (int)Session["AracID"];
            decimal komisyonUcreti = (decimal)Session["komisyonUcreti"];

            var gelenNoterBilgisi = new KurumsalAracDAL().NoterUcretiGetir(id);
            var gelenKomisyonBilgisi = new KurumsalAracDAL().KomisyonUcretiGetir(id);

            ViewBag.Toplam =  gelenNoterBilgisi.Ucret + komisyonUcreti;

            var noterVeKomisyonVM = new NoterVeKomisyonUcretVM();
            
                noterVeKomisyonVM = new NoterVeKomisyonUcretVM()
                {
                    KomisyonUcreti = gelenKomisyonBilgisi,
                    NoterUcreti = gelenNoterBilgisi
                };
            

            return View(noterVeKomisyonVM);
        }

        [HttpGet]
        public ActionResult NoterVeKomisyon(decimal fiyat)
        {

            int id = (int)Session["AracID"];

            var komisyonTutari = new KurumsalAracDAL().AracUcretBilgisineGoreKomisyonGetir(fiyat);
            Session["komisyonUcreti"] = komisyonTutari;

            var gelenNoterBilgisi = new KurumsalAracDAL().NoterUcretiGetir(id);


            var noterVeKomisyonVM = new NoterVeKomisyonUcretVM();

            if (gelenNoterBilgisi != null)
            {
                return RedirectToAction("NoterVeKomisyonToplami");
            }
            else
            {
                var komisyon = new KomisyonUcretVM()
                {
                    AracUcret = komisyonTutari,
                    AracID = id
                };

                noterVeKomisyonVM = new NoterVeKomisyonUcretVM()
                {
                    KomisyonUcreti = komisyon,
                    NoterUcreti = new NoterUcretVM()
                    {
                        AracID = id
                    }
                };
            }

            return View(noterVeKomisyonVM);
        }

        [HttpPost]
        public ActionResult NoterVeKomisyon(NoterVeKomisyonUcretVM vm)
        {
            int id = (int)Session["AracID"];
            decimal komisyonUcreti = (decimal)Session["komisyonUcreti"];

            var kurumsalAracIslemleri = new KurumsalAracDAL();

  
            var belirlenenKomisyonID = kurumsalAracIslemleri.AracUcretBilgisineGoreKomisyonIDGetir(komisyonUcreti);

            new NoterVeKomisyonUcretEkleDAL().DBKomisyonVeNoterUcretEkle(vm, belirlenenKomisyonID, id);



            return RedirectToAction("AracGuncelle");

        }

        [HttpGet]
        public ActionResult TramerKaydi()
        {
            int id = (int)Session["AracID"];

            var tramerUcret = new AracTramerDAL().AracTramerUcretGetir(id);


            var aracDurum = new AracTramerDAL().AracDurumGetir(id);

            var aracTramerBilgileriVM = new AracTramerBilgileriGetirDAL().AracTramerBilgileriniGetir();

            var aracTramerKaydi = new AracTramerKaydiVM
            {
                AracTramer = new AracTramerVM
                {
                    AracTramerUcreti = tramerUcret,
                    AracParcaDurumlari = aracTramerBilgileriVM.AracParcaDurumlari,
                    AracParcalari = aracTramerBilgileriVM.AracParcalari
                },
                AracDurum = aracDurum
            };

            return View(aracTramerKaydi);
        }

        [HttpGet]
        public ActionResult TramerBilgisi()
        {
            int id = (int)Session["AracID"];
            var aracDurum = new AracTramerDAL().AracDurumGetir(id);

            if (aracDurum.Count != 0)
            {
                return RedirectToAction("TramerKaydi");
            }

            var aracTramerBilgileriVM = new AracTramerBilgileriGetirDAL().AracTramerBilgileriniGetir();

            return View(aracTramerBilgileriVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TramerBilgisi(AracTramerVM vm,FormCollection form)
        {

            int id = (int)Session["AracID"];

            new AracTramerBilgileriGetirDAL().AracTramerBilgisiEkle(form, id, vm);

        
            return RedirectToAction("TramerBilgisi");

        }

        [HttpGet]
        public ActionResult AracSatis(int aracID)
        {
            KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();
            List<SirketVM> sirketler = kurumsalArac.SirketGetir();

            List<SirketVM> secilenSirketler = null;
            using (var db = new IkinciElAracSatisContext())
            {
                var sirketID = db.KurumsalKullaniciAracDetaylari.FirstOrDefault(a => a.AracID == aracID).SirketID;
                secilenSirketler = sirketler.Where(a => a.SirketID != sirketID).ToList();
            }

            var aracSatisBilgieri = new AracSatisVM
            {
                AracID = aracID,
                Sirketler = secilenSirketler.Select(a => new SelectListItem()
                {
                    Text = a.Sirket,
                    Value = a.SirketID.ToString()
                }).ToList(),
            };

            return View(aracSatisBilgieri);
        }

        [HttpPost]
        public ActionResult AracSatis(AracSatisVM vm)
        {

            KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();
            kurumsalArac.KullaniciAracStokMiktariniAzalt(vm.AracID);

            kurumsalArac.KurumsalAracDetayGuncelle(vm.SirketID, vm.AracID);
            using (var db = new IkinciElAracSatisContext())
            {
                var kurumsalAracDetayID = db.KurumsalKullaniciAracDetaylari.FirstOrDefault(a => a.SirketID == vm.SirketID).AracID;
                kurumsalArac.KullaniciAracStokMiktariGucenlle(kurumsalAracDetayID);
            }
            
            return RedirectToAction("AracGuncelle");
        }



    }
}