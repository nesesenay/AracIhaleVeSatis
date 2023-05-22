using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.DAL.KullaniciGirisi;
using IkınciElAracSatis.UI.DAL.KullaniciGirisi;
using IkınciElAracSatis.UI.Filters;
using IkınciElAracSatis.UI.Models;
using IkınciElAracSatis.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IkınciElAracSatis.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
          
            return View();
        }

        [HttpPost]
        [CheckUser]
        [ValidateAntiForgeryToken]
        public ActionResult Index(KullaniciVM vm)
        {


            ProfilBilgileriDAL dal = new ProfilBilgileriDAL
                  ();


            List<KullaniciVM> kullanicilar = dal.KullaniciGetir();


            var kullanici = kullanicilar.FirstOrDefault(a => a.Email == vm.Email && a.Sifre == vm.Sifre);

            if (kullanici.RolID == 3)
            {
             
                Session["UserId"] = kullanici.KullaniciID;
                return RedirectToAction("Index", "Home");
            }



            return RedirectToAction("Index");

        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


    }
}