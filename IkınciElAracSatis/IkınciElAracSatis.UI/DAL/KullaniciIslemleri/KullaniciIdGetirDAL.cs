using IkınciElAracSatis.CORE.Context;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.DAL.KullaniciGirisi
{
    public class KullaniciIdGetirDAL
    {
        public int? KullaniciIdGetir(KullaniciVM vm)
        {
            using (IkinciElAracSatisContext db = new IkinciElAracSatisContext())
            {
                var kullanici = db.Kullanicilar.SingleOrDefault(x => x.Email == vm.Email && x.Sifre == vm.Sifre);
                if (kullanici != null)
                {
                    return kullanici.KullaniciID;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}