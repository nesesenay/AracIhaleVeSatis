using IkınciElAracSatis.CORE.Context;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models;
using IkınciElAracSatis.UI.Models.VM.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkınciElAracSatis.DAL.KullaniciGirisi
{
    public class ProfilBilgileriDAL
    {
        IkinciElAracSatisContext db = new IkinciElAracSatisContext();

        public List<KullaniciVM> KullaniciGetir()
        {
            return (from k in db.Kullanicilar
                    select new KullaniciVM()
                    {
                        KullaniciID = k.KullaniciID,
                        Email = k.Email,
                        Sifre = k.Sifre,
                        RolID = k.RolID,

                    }).ToList();
        }

        public AdminProfilVM ProfilBilgileriniGetir(int? id)
        {
            return (from a in db.Kullanicilar
                    join ad in db.AdminKullanicilari on a.KullaniciID equals ad.KullaniciID
                    where a.KullaniciID == id
                    select new AdminProfilVM()
                    {
                        KullaniciID = a.KullaniciID,
                        Ad = a.Ad,
                        Soyad = a.Soyad,
                        Telefon = a.Telefon,
                        Email = a.Email,
                        Sifre = a.Sifre,
                        HesapAktifMi = ad.HesapAktifMi
                    }).SingleOrDefault();
        }


        public List<AdminProfilVM> AdminKullanicilariGetir()
        {
            return (from a in db.Kullanicilar
                    join ad in db.AdminKullanicilari on a.KullaniciID equals ad.KullaniciID
                    select new AdminProfilVM()
                    {
                        KullaniciID = a.KullaniciID,
                        Ad = a.Ad,
                        Soyad = a.Soyad,
                        Telefon = a.Telefon,
                        Email = a.Email,
                        Sifre = a.Sifre,
                        HesapAktifMi = ad.HesapAktifMi
                    }).ToList();
        }

        public int AdminProfilGuncelle(ProfilVM vm)
        {
            var eskiProfilBilgileri = db.Kullanicilar.Find(vm.KullaniciID);
            eskiProfilBilgileri.Ad = vm.Ad;
            eskiProfilBilgileri.Soyad = vm.Soyad;
            eskiProfilBilgileri.Email = vm.Email;
            eskiProfilBilgileri.Sifre = vm.Sifre;
            eskiProfilBilgileri.Telefon = vm.Telefon;
            return db.SaveChanges();
        }
    }
}
