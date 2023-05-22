using IkınciElAracSatis.CORE.Context;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkınciElAracSatis.DAL.KullaniciGirisi
{
    public class AdminKullaniciDAL
    {
        IkinciElAracSatisContext db = new IkinciElAracSatisContext();

        public List<AdminKullaniciVM> RolBilgisineGoreKullaniciGetir()
        {
            return (from k in db.AdminKullanicilari
                    select new AdminKullaniciVM()
                    {
                        Email = k.Email,
                        Sifre = k.Sifre,
                    }).ToList();
        }
    }
}
