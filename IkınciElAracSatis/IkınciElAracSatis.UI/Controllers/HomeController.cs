using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.DAL.KurumsalKullaniciAracListele;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracFiltrele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IkınciElAracSatis.UI.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
                KurumsalKullaniciAracFiltreleDAL KurumsalKullaniciAracFiltrele = new KurumsalKullaniciAracFiltreleDAL();

                AracListeleVM aracListeleVM = KurumsalKullaniciAracFiltrele.KurumsalAracGetir();

                return View(aracListeleVM);
        }



    }
}