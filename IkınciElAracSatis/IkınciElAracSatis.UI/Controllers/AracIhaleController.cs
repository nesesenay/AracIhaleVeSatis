using IkınciElAracSatis.CORE.Entities;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.DAL.IhaleIslemleri;
using IkınciElAracSatis.UI.Models.VM.AracIhale;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace IkınciElAracSatis.UI.Controllers
{
    [Authorize]
    public class AracIhaleController : Controller
    {
        
        public ActionResult Index()
        {
            IhaleIslemleriDAL ihaleIslemleriDAL = new IhaleIslemleriDAL();

            var ihaleLİstesi = ihaleIslemleriDAL.KaydedilenIhaleBilgileriniGetir();

            return View(ihaleLİstesi);
        }

        [HttpGet]
        public ActionResult IhaleEkle()
        {
            IhaleEklemeDAL dal = new IhaleEklemeDAL();
            var eklenecekIhaleBilgileri = dal.AracIhaleleriniGetir();

            return View(eklenecekIhaleBilgileri);
        }

        [HttpPost]
        public ActionResult IhaleEkle(DBAracIhaleVM vm)
        {
            IhaleEklemeDAL dal = new IhaleEklemeDAL();
            IhaleIslemleriDAL ihaleIslemleriDAL = new IhaleIslemleriDAL();

            int userId = (int)Session["UserId"];


            var eklenecekIhale = ihaleIslemleriDAL.IhaleBilgileriGetir(vm, userId);

            dal.AracIhaleEkle(eklenecekIhale);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IhaleDetay(int aracIhaleID)
        {

            int eklenenAracIhaleID = Session["aracIhaleID"] as int? ?? 0;
            if (aracIhaleID != 0)
            {
                Session["ihaleID"] = aracIhaleID;
            }
            int ihaleID = (int)Session["ihaleID"];

            if (aracIhaleID == 0)
            {
                aracIhaleID = eklenenAracIhaleID;
            }

            if (eklenenAracIhaleID == 0)
            {
                aracIhaleID = ihaleID;
            }


            IhaleEklemeDAL dal = new IhaleEklemeDAL();
            var ihaleDteayi = dal.IhaleDetayiniListele(aracIhaleID);

            return View(ihaleDteayi);
        }

        [HttpGet]
        public ActionResult AracEkle(int aracIhaleID)
        {
            Session["aracIhaleID"] = aracIhaleID;

            IhaleIslemleriDAL dal = new IhaleIslemleriDAL();
            var araclar = dal.AracBilgileriniGetir();

            if (araclar == null)
            {
                TempData["Message"] = "İhaleyi açan şirkete ait araç bulunmamaktadır.";
                return RedirectToAction("IhaleDetay");
            }

            var belirlenenIhaleFiyati = new DBIhaleFiyatBelirlemeVM()
            {
                Araclar = araclar.Select(a => new SelectListItem()
                {
                    Value = a.AracID.ToString(),
                    Text = a.AracID.ToString()
                }).ToList()
            };

            return View(belirlenenIhaleFiyati);
        }

        [HttpPost]
        public ActionResult AracEkle(DBIhaleFiyatBelirlemeVM dto)
        {
            int eklenenAracIhaleID = (int)Session["aracIhaleID"];

            if (eklenenAracIhaleID != 0)
            {
                IhaleIslemleriDAL dal = new IhaleIslemleriDAL();
                dal.EklenecekIhaleFiyatBilgileriniGetir(dto,eklenenAracIhaleID);
            }

            return RedirectToAction("IhaleDetay");
        }
    }
}