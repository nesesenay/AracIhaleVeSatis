using IkınciElAracSatis.UI.Models.VM;
using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using IkınciElAracSatis.CORE.Context;

namespace IkınciElAracSatis.UI.DAL.KurumsalAracIslemleri
{
    public class KurumsalAracBilgileriDAL
    {

        IkinciElAracSatisContext db = new IkinciElAracSatisContext();
        public IlanBilgi AracIlanBilgisiEkle(IlanBilgiVM vm)
        {
            var ilanBilgisi = db.IlanBilgileri.Add(new IlanBilgi()
            {
                AracID = vm.AracID,
                IlanBasligi = vm.IlanBasligi,
                Aciklama = vm.Aciklama
            });
            int i = db.SaveChanges();
            return ilanBilgisi;
        }
        public List<MusteriRolVM> MusteriRolBilgileriniGetir()
        {
            return (from k in db.Roller
                    select new MusteriRolVM()
                    {
                        RolID = k.RolID,
                        Rol = k.KullaniciRol
                    }).ToList();
        }
        public List<IlanBilgiVM> AracIlanBilgileriniGetir()
        {
            return (from i in db.IlanBilgileri
                    select new IlanBilgiVM()
                    {
                        AracID = i.AracID,
                        Aciklama = i.Aciklama,
                        IlanBasligi = i.IlanBasligi
                    }).ToList();

        }
    }
}