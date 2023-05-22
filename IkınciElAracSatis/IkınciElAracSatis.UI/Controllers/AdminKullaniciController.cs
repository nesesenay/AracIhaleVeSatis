using IkınciElAracSatis.DAL.KullaniciGirisi;
using IkınciElAracSatis.UI.Models;
using IkınciElAracSatis.UI.Models.VM.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Controllers
{
    public class AdminKullaniciController : Controller
    {
        [Authorize]
   
        // GET: AdminKullanici
        public ActionResult Index()
        {
                int userId = (int)Session["UserId"];
                ProfilBilgileriDAL kullanici = new ProfilBilgileriDAL();
                AdminProfilVM kullaniciVM = kullanici.ProfilBilgileriniGetir(userId);

                return View(kullaniciVM);
        }

        [HttpGet]

        public ActionResult Guncelle(int? id)
        {
            //http statusCode 
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            //db ye bağlan 5 nolu datayı getir. 
            ProfilBilgileriDAL kullanici = new ProfilBilgileriDAL();
            AdminProfilVM gelenProfilBilgisi = kullanici.ProfilBilgileriniGetir(id);
            if (gelenProfilBilgisi == null)
            {
                return HttpNotFound();
            }
            return View(gelenProfilBilgisi);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult Guncelle(ProfilVM profilVM)
        {

                ProfilBilgileriDAL adminKullanici = new ProfilBilgileriDAL();
                int etkilenenSatirSayisi = adminKullanici.AdminProfilGuncelle(profilVM);

                if (etkilenenSatirSayisi > 0)
                {
                return RedirectToAction("Index");
                }

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
    }
}