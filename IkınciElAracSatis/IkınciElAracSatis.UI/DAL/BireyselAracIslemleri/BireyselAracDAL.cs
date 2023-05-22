using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.CORE.Entities;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.DAL.BireyselAracIslemleri
{
    public class BireyselAracDAL
    {
        IkinciElAracSatisContext db = new IkinciElAracSatisContext();
        public List<BireyselAracStatuVM> BireyselAracStatuleriniGetir()
        {
            return (from b in db.BireyselAracStatuleri
                    select new BireyselAracStatuVM()
                    {
                        BireyselAracStatuID = b.BireyselAracStatuID,
                        AracStatu = b.AracStatu
                    }).ToList();
        }

        public List<BireyselAracSahipVM> BireyselAracSahipleriniGetir()
        {
            return (from b in db.BireyselAracSahipleri
                    select new BireyselAracSahipVM()
                    {
                        AracID = b.AracID,
                        KullaniciID = b.KullaniciID
                    }).ToList();
        }

        public List<OnDegerlemeFiyatVM> OnDegerlemeTutarlariniGetir()
        {
            return (from b in db.BireyselOnDegerlemeTutarlari
                    select new OnDegerlemeFiyatVM()
                    {
                        AracID = b.AracID,
                        KullaniciID = b.KullaniciID,
                        OnayliMi = b.OnayliMi,
                        OnDegerlemeTutari = b.OnDegerlemeTutari
                    }).ToList();
        }

        public List<AracTarihceVM> BireyselAracTarihceGetir(int id)
        {
            return (from k in db.BireyselAracTarihceleri
                    join s in db.BireyselAracStatuleri on k.BireyselAracStatuID equals s.BireyselAracStatuID
                    where k.AracID == id
                    select new AracTarihceVM()
                    {
                        AracID = k.AracID,
                        AracStatuID = k.BireyselAracStatuID,
                        DegistirilmeTarihi = k.DegistirilmeTarihi,
                        Statu = s.AracStatu
                    }).ToList();
        }

        public List<TeklifFiyatiUcretVM> TeklifFiyatlariniGetir()
        {
            return (from b in db.AracUcretleri
                    select new TeklifFiyatiUcretVM()
                    {
                        AracID = b.AracID,
                        AracUcretTipID = b.AracUcretTipID,
                        ParaBirimiID = b.ParaBirimiID,
                        Ucret = b.Ucret 
                    }).ToList();
        }

        public bool DBBireyselTarihceEkle(DBBireyselAracTarihceVM vm)
        {
            db.BireyselAracTarihceleri.Add(new BireyselAracTarihce()
            {
                AracID = vm.AracID,
                DegistirilmeTarihi = vm.DegistirilmeTarihi,
                BireyselAracStatuID = vm.BireyselAracStatuID
            });


            return db.SaveChanges() > 0;
        }

        public bool OnDegerlemeTutariEkle(OnDegerlemeFiyatVM vm)
        {
            db.BireyselOnDegerlemeTutarlari.Add(new OnDegerlemeTutar()
            {
                AracID = vm.AracID,
                KullaniciID = vm.KullaniciID,
                OnayliMi = vm.OnayliMi,
                OnDegerlemeTutari = vm.OnDegerlemeTutari
            });


            return db.SaveChanges() > 0;
        }

        public bool TeklifFiyatiEkle(TeklifFiyatiUcretVM vm)
        {
            db.AracUcretleri.Add(new AracUcret()
            {
                AracID = vm.AracID,
                Ucret = vm.Ucret,
                AracUcretTipID = vm.AracUcretTipID,
                ParaBirimiID = vm.ParaBirimiID
            });


            return db.SaveChanges() > 0;
        }

        public int OnDegerlemeTutariGuncelle(int aracID, OnDegerlemeFiyatVM vm)
        {
            var onDegerlemeTutari = db.BireyselOnDegerlemeTutarlari.Find(aracID);
            onDegerlemeTutari.OnDegerlemeTutari = vm.OnDegerlemeTutari;
            return db.SaveChanges();
        }

        public int TeklifFiyatiGuncelle(int aracID, TeklifFiyatiUcretVM vm)
        {
            var teklifFiyati = db.AracUcretleri.Find(aracID);
            teklifFiyati.Ucret = vm.Ucret;
            return db.SaveChanges();
        }

        public int BireyselAracSahipGuncelle(int id, string isim)
        {
            var aracSahibi = db.BireyselAracSahipleri.FirstOrDefault(a => a.AracID == id);
            var kullanici = db.Kullanicilar.Find(aracSahibi.KullaniciID);
            string[] kelimeler = isim.Split(' ');
            kullanici.Ad = kelimeler[0];
            kullanici.Soyad = kelimeler[1];
            return db.SaveChanges();
        }
    }
}