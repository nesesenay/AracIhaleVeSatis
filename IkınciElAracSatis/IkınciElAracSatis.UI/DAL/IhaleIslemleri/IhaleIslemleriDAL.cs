using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.UI.Models.VM.AracIhale;
using IkınciElAracSatis.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Contexts;

namespace IkınciElAracSatis.UI.DAL.IhaleIslemleri
{

    public class IhaleIslemleriDAL
    {

        IkinciElAracSatisContext db = new IkinciElAracSatisContext();

        public List<IhaleStatuVM> IhaleStatuleriGetir()
        {
            return (from a in db.IhaleStatuleri
                    select new IhaleStatuVM()
                    {
                        IhaleninSatusu = a.IhaleninSatusu,
                        IhaleStatuID = a.IhaleStatuID
                    }).ToList();
        }

        public List<AracVM> AracBilgileriniGetir()
        {
            return (from a in db.Araclar
                    select new AracVM()
                    {
                        AracID = a.AracID,
                        AracNo = a.AracNo
                    }).ToList();
        }

        public AracIhaleVM IhaleBilgileriGetir(DBAracIhaleVM vm, int kullaniciID)
        {
            return new AracIhaleVM()
            {
                KullaniciID = kullaniciID,
                IhaleAdi = vm.IhaleAdi,
                IhaleBaslangicSaati = vm.IhaleBaslangicSaati,
                IhaleBaslangicTarihi = vm.IhaleBaslangicTarihi,
                IhaleBitisSaati = vm.IhaleBitisSaati,
                IhaleBitisTarihi = vm.IhaleBitisTarihi,
                IhaleStatuID = vm.IhaleStatuID,
                KaydetmeTarihi = vm.KaydetmeTarihi,
                RolID = vm.RolID,
                SirketID = vm.SirketID
            };
        }

        public void EklenecekIhaleFiyatBilgileriniGetir(DBIhaleFiyatBelirlemeVM vm, int eklenenAracIhaleID)
        {
            var fiyatBelirlemeVM = new IhaleFiyatBelirlemeVM()
            {
                AracID = vm.AracID,
                IhaleBaslangicFiyati = vm.IhaleBaslangicFiyati,
                MinimumAlimFiyati = vm.MinimumAlimFiyati,
            };

            IhaleEklemeDAL ihaleEkle = new IhaleEklemeDAL();
            ihaleEkle.IhaleyeFiyatEkle(fiyatBelirlemeVM);

            var aracEklemeVM = new IhaleyeAracEklemeVM()
            {
                AracIhaleID = eklenenAracIhaleID,
                AracID =vm.AracID
            };

            ihaleEkle.IhaleyeAracEkle(aracEklemeVM);


        }

        public List<IhaleListeleVM> KaydedilenIhaleBilgileriniGetir()
        {

            var ihaleListesi =  (from a in db.AracIhaleleri
                                join k in db.Kullanicilar on a.KullaniciID equals k.KullaniciID
                                join r in db.Roller on a.RolID equals r.RolID
                                join s in db.IhaleStatuleri on a.IhaleStatuID equals s.IhaleStatuID
                                join si in db.Sirketler on a.SirketID equals si.SirketID
                                select new IhaleListeleVM()
                                {
                                    AracIhaleID = a.AracIhaleID,
                                    Kullanici = k.Ad + " " + k.Soyad,
                                    Rol = r.KullaniciRol,
                                    IhaleStatu = s.IhaleninSatusu,
                                    IhaleAdi = a.IhaleAdi,
                                    IhaleBaslangicSaati = a.IhaleBaslangicSaati,
                                    IhaleBaslangicTarihi = a.IhaleBaslangicTarihi,
                                    IhaleBitisSaati = a.IhaleBaslangicSaati,
                                    IhaleBitisTarihi = a.IhaleBitisTarihi,
                                    KaydetmeTarihi = a.KaydetmeTarihi,
                                    Sirket = si.SirketAdi

                                }).ToList();


            return ihaleListesi;


        }

        public List<AracIhaleListeleVM> AracIhaleLİstesiniGetir()
        {

            var ihaleListesi = (from a in db.Araclar
                                join mo in db.Modeller on a.ModelID equals mo.ModelID
                                join ma in db.Markalar on mo.MarkaID equals ma.MarkaID
                                join k in db.Kullanicilar on a.KullaniciID equals k.KullaniciID
                                join i in db.IhaleyeAracEklemeleri on a.AracID equals i.AracID
                                join f in db.IhaleFiyatBelirlemeleri on i.AracID equals f.AracID
                                join ai in db.AracIhaleleri on i.AracIhaleID equals ai.AracIhaleID
                                join r in db.Roller on ai.RolID equals r.RolID
                                join kad in db.KurumsalKullaniciAracDetaylari on a.AracID equals kad.AracID
                                join s in db.AracStatuleri on kad.AracStatuID equals s.AracStatuID
                                where i.AracID == a.AracID
                                select new AracIhaleListeleVM()
                                {
                                    AracIhaleID = ai.AracIhaleID,
                                    AracID = a.AracID,
                                    Model = mo.ModelAdi,
                                    Marka = ma.MarkaAdi,
                                    KaydedenKul = k.Ad + " " + k.Soyad,
                                    Fiyat = f.IhaleBaslangicFiyati,
                                    KaydedilenZaman = ai.KaydetmeTarihi,
                                    Rol = r.KullaniciRol,
                                    Statu = s.AracStatusu
                                }).ToList();


            return ihaleListesi;



        }
    }
}