using IkınciElAracSatis.CORE.Context;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.AracIhale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.DAL.IhaleIslemleri
{
    public class IhaleEklemeDAL
    {
        IkinciElAracSatisContext db = new IkinciElAracSatisContext();
        public void AracIhaleEkle(AracIhaleVM vm)
        {

            db.AracIhaleleri.Add(new AracIhale()
            {
                KullaniciID= vm.KullaniciID,
                IhaleAdi = vm.IhaleAdi,
                IhaleBaslangicSaati = vm.IhaleBaslangicSaati.ToString(),
                IhaleBaslangicTarihi = vm.IhaleBaslangicTarihi,
                IhaleBitisSaati = vm.IhaleBitisSaati.ToString(),
                IhaleBitisTarihi = vm.IhaleBitisTarihi,
                IhaleStatuID = vm.IhaleStatuID,
                KaydetmeTarihi = DateTime.Now,
                RolID = vm.RolID,
                SirketID = vm.SirketID
            });

            int a = db.SaveChanges();
        }

        public void IhaleyeFiyatEkle(IhaleFiyatBelirlemeVM vm)
        {

            db.IhaleFiyatBelirlemeleri.Add(new IhaleFiyatBelirleme()
            {
                AracID= vm.AracID,
                IhaleBaslangicFiyati = vm.IhaleBaslangicFiyati,
                MinimumAlimFiyati = vm.MinimumAlimFiyati,
                ParaBirimID= 1
            });

            int a = db.SaveChanges();
        }

        public void IhaleyeAracEkle(IhaleyeAracEklemeVM vm)
        {

            db.IhaleyeAracEklemeleri.Add(new IhaleyeAracEkleme()
            {
                AracIhaleID = vm.AracIhaleID,
                AracID = vm.AracID
            });

            int a = db.SaveChanges();
        }

        public IhaleDetayVM IhaleDetayiniListele(int aracIhaleID)
        {

            IhaleIslemleriDAL ihaleIslemleriDAL = new IhaleIslemleriDAL();
            var ihaleyeEklenenAracListesi = ihaleIslemleriDAL.AracIhaleLİstesiniGetir();

            var ihaleyeEklenenAraclar = ihaleyeEklenenAracListesi.Where(a => a.AracIhaleID == aracIhaleID).ToList();

            if (ihaleyeEklenenAraclar.Count == 0)
            {
                ihaleyeEklenenAraclar = new List<AracIhaleListeleVM>();
            }

            var ihaleListesi = ihaleIslemleriDAL.KaydedilenIhaleBilgileriniGetir();

           var secilenIhale = ihaleListesi.FirstOrDefault(a => a.AracIhaleID == aracIhaleID);

            return new IhaleDetayVM()
            {
                AracIhaleListesi = ihaleyeEklenenAraclar,
                IhaleBilgisi = secilenIhale
            };
        }



        public DBAracIhaleVM AracIhaleleriniGetir()
        {
            KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();
            IhaleIslemleriDAL ihaleIslemleri = new IhaleIslemleriDAL();

            List<SirketVM> sirketler = kurumsalArac.SirketGetir();
            List<IhaleStatuVM> statuler = ihaleIslemleri.IhaleStatuleriGetir();
            List<MusteriRolVM> roller = kurumsalArac.MusteriRolBilgileriniGetir();
            var secilenRoller = roller.Where(a => a.RolID == 1 || a.RolID == 2).ToList();

            return new DBAracIhaleVM()
            {
                Roller = secilenRoller.Select(a => new SelectListItem()
                {
                    Text = a.Rol,
                    Value = a.RolID.ToString()
                }).ToList(),
                Sirketler = sirketler.Select(a => new SelectListItem()
                {
                    Text = a.Sirket,
                    Value = a.SirketID.ToString()
                }).ToList(),
                IhaleStatuleri = statuler.Select(a => new SelectListItem()
                {
                    Text = a.IhaleninSatusu,
                    Value = a.IhaleStatuID.ToString()
                }).ToList(),
            };

        }

     
    }
}