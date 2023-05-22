using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.UI.Models.VM;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models.VM.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IkınciElAracSatis.UI.Models;
using IkınciElAracSatis.UI.Models.VM.KullaniciRol;
using System.Data.Entity;

namespace IkınciElAracSatis.UI.DAL.Kullanici
{
    public class KullaniciDAL
    {

        IkinciElAracSatisContext db = new IkinciElAracSatisContext();

        public List<BireyselKullaniciVM> BireyselKullaniciGetir()
        {
            return (from k in db.Kullanicilar
                    join bk in db.BireyselKullanicilar on k.KullaniciID equals bk.KullaniciID
                    select new BireyselKullaniciVM()
                    {
                        Ad = k.Ad,
                        Soyad = k.Soyad,
                        BireyselKullaniciID = k.KullaniciID,
                        CepTelefonu = k.Telefon,
                        Email = k.Email,
                        Sifre = k.Sifre 
                    }).ToList();
        }

        public List<KurumsalKullaniciVM> KurumsalKullaniciGetir()
        {
            return (from k in db.Kullanicilar
                    join kk in db.KurumsalKullanicilar on k.KullaniciID equals kk.KullaniciID
                    join s in db.Sirketler on kk.SirketID equals s.SirketID
                    where k.RolID != 3
                    select new KurumsalKullaniciVM()
                    {
                        Ad = k.Ad,
                        Soyad = k.Soyad,
                        Email = k.Email,
                        Sifre= k.Sifre,
                        CepTelefonu= k.Telefon,
                        Adres = k.Adres,
                        AracStokMiktari = kk.AracStokMiktari,
                        OnayliMi = kk.OnayliMi,
                        KurumsalKullaniciID = k.KullaniciID,
                        SirketAdi = s.SirketAdi,
                        SirketBilgisi = kk.SirketBilgisi,
                        İl = k.İl,
                        İlce = k.İlce
                    }).ToList();
        }

        public List<PaketVM> KullaniciPaketleriGetir()
        {
            return (from p in db.Paketler
                    select new PaketVM()
                    {
                      PaketID = p.PaketID,
                      PaketAdi = p.PaketAdi
                    }).ToList();
        }

        public bool KurumsalKullaniciPaketTanimla(KullaniciPaketVM vm)
        {
            var tanimlananPaket = db.PaketTanimlamalari.Add(new PaketTanimlama()
            {
                KullaniciID=vm.KurumsalKullanici.KurumsalKullaniciID,
                PaketID = vm.KullaniciPaketleri.PaketID 
            });
            return db.SaveChanges() > 0;
        }

        public int AracGuncelle(SecilenAracVM vm, int id)
        {
            var eskiAracBilgileri = db.Araclar.Find(id);
            eskiAracBilgileri.PlakaID = vm.PlakaID;
            var modelID = eskiAracBilgileri.ModelID = vm.ModelID;
            eskiAracBilgileri.GarantiliMi = vm.GrantiliMi;
            var model = db.Modeller.Where(a => a.ModelID == modelID).FirstOrDefault();
            model.MarkaID = vm.MarkaID;
            return db.SaveChanges();
        }

        public int KurumsalKullaniciPaketGuncelle(PaketVM vm, int kullaniciID)
        {
            var eskiPaketBilgisi = db.PaketTanimlamalari.FirstOrDefault(a => a.KullaniciID == kullaniciID);
            db.PaketTanimlamalari.Remove(eskiPaketBilgisi);

            var yeniPaket = new PaketTanimlama
            {
                PaketID = vm.PaketID,
                KullaniciID = kullaniciID,
                                          
            };

            db.PaketTanimlamalari.Add(yeniPaket);


            return db.SaveChanges();
        }

        public bool KurumsalKullaniciOnay(KurumsalKullaniciVM vm)
        {
            var onaylananKullanici = db.KurumsalKullanicilar.FirstOrDefault(a => a.KullaniciID == vm.KurumsalKullaniciID);
            onaylananKullanici.OnayliMi = vm.OnayliMi;
            return db.SaveChanges() > 0;
        }

        public KurumsalKullaniciVM IDBilgisineGoreKurumsalKullaniciGetir(int id)
        {
            return (from k in db.Kullanicilar
                    join kk in db.KurumsalKullanicilar on k.KullaniciID equals kk.KullaniciID
                    join s in db.Sirketler on kk.SirketID equals s.SirketID
                    where k.KullaniciID == id
                    select new KurumsalKullaniciVM()
                    {
                        Ad = k.Ad,
                        Soyad = k.Soyad,
                        Email = k.Email,
                        Sifre = k.Sifre,
                        CepTelefonu = k.Telefon,
                        Adres = k.Adres,
                        AracStokMiktari = kk.AracStokMiktari,
                        OnayliMi = kk.OnayliMi,
                        KurumsalKullaniciID = k.KullaniciID,
                        SirketAdi = s.SirketAdi,
                        SirketBilgisi = kk.SirketBilgisi,
                        İl = k.İl,
                        İlce = k.İlce
                    }).FirstOrDefault();
        }
    }
}