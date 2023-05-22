using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.DAL.KullaniciGirisi;
using IkınciElAracSatis.UI.Models;

using IkınciElAracSatis.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace IkınciElAracSatis.UI.Filters
{
    public class CheckUser: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters["vm"] != null)
            {
                var urldekiDegisken = filterContext.ActionParameters["vm"] as KullaniciVM;
                ProfilBilgileriDAL kullanicilar = new ProfilBilgileriDAL
                    ();

                List<KullaniciVM> gelenKullanicilar = kullanicilar.KullaniciGetir();

              

                bool uyeMi = false;
                foreach (var item in gelenKullanicilar)
                {
                    if (urldekiDegisken.Email == item.Email && urldekiDegisken.Sifre == item.Sifre )
                    {
                        FormsAuthentication.SetAuthCookie(urldekiDegisken.Email, false);
                        uyeMi = true;
                        HttpContext.Current.Session.Add("kullaniciGirisi", "başarılı");
                    }
                    else if (uyeMi != true)
                    {
                        uyeMi = false;
                    }
                }

                if (uyeMi == false)
                {
                    filterContext.Result = new RedirectResult("Login/Index");
                    HttpContext.Current.Session.Add("kullaniciGirisi", "başarısız");
                }

            }
        }
    }
}