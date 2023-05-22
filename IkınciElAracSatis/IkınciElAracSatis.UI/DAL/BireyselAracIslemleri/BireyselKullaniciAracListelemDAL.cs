using IkınciElAracSatis.UI.Models.VM.KurumsalAracFiltrele;
using IkınciElAracSatis.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IkınciElAracSatis.CORE.Context;
using System.Web.Mvc;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri;
using IkınciElAracSatis.UI.Models.VM.KullaniciRol;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using System.Security.Cryptography;
using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using IkınciElAracSatis.UI.DAL.Kullanici;

namespace IkınciElAracSatis.UI.DAL.BireyselAracIslemleri
{
    public class BireyselKullaniciAracListelemDAL
    {
        IkinciElAracSatisContext db = new IkinciElAracSatisContext();
        public BireyselAracListeleVM BireyselAraclariGetir()
        {
            KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();
            BireyselAracDAL bireyselArac = new BireyselAracDAL();

            List<ModelVM> modeller = kurumsalArac.ModelGetir();
            List<MarkaVM> markalar = kurumsalArac.MarkaGetir();
            List<BireyselAracStatuVM> aracStatuleri = bireyselArac.BireyselAracStatuleriniGetir();


            var aracFiltrelemeVM = new BireyselAracFiltreleVM()
            {
                Modeller = modeller.Select(a => new SelectListItem()
                {
                    Text = a.ModelAdi,
                    Value = a.ModelID.ToString()
                }).ToList(),
                Markalar = markalar.Select(a => new SelectListItem()
                {
                    Text = a.MarkaAdi,
                    Value = a.MarkaID.ToString(),
                }).ToList(),
                BireyselAracStatuleri = aracStatuleri.Select(a => new SelectListItem()
                {
                    Text = a.AracStatu,
                    Value = a.BireyselAracStatuID.ToString()
                }).ToList()
            };



            List<BireyselAracGetirVM> aracGetirVM = (from a in db.Araclar
                                             join m in db.Modeller on a.ModelID equals m.ModelID
                                             join ma in db.Markalar on m.MarkaID equals ma.MarkaID
                                             join bk in db.BireyselKullaniciAracDetaylari on a.AracID equals bk.AracID
                                             join ku in db.Kullanicilar on a.KullaniciID equals ku.KullaniciID
                                             join st in db.BireyselAracStatuleri on bk.BireyselAracStatuID equals st.BireyselAracStatuID
                                             where a.AracID == bk.AracID
                                             group new { a, m, ma, bk, st, ku } by a.AracID into aracDetay
                                             select new BireyselAracGetirVM()
                                             {
                                                 AracID = aracDetay.Key,
                                                 AracNo = aracDetay.FirstOrDefault().a.AracNo,
                                                 ModelID = aracDetay.FirstOrDefault().m.ModelID,
                                                 MarkaID = aracDetay.FirstOrDefault().ma.MarkaID,
                                                 AdminID = aracDetay.FirstOrDefault().a.KullaniciID,
                                                 KaydedilenTarih = aracDetay.FirstOrDefault().a.KaydedilenTarih,
                                                 ModelAdi = aracDetay.FirstOrDefault().m.ModelAdi,
                                                 MarkaAdi = aracDetay.FirstOrDefault().ma.MarkaAdi,
                                                 AdminAdi = aracDetay.FirstOrDefault().ku.Ad,
                                                 BireyselStatu = aracDetay.FirstOrDefault().st.AracStatu,
                                                 BireyselStatuID = aracDetay.FirstOrDefault().st.BireyselAracStatuID,
                                             }).ToList();


            return new BireyselAracListeleVM
            {
               BireyselAracFiltreleri = aracFiltrelemeVM,
               BireyselAraclar = aracGetirVM
            };
        }


        public BireyselAracGuncelleVM GuncellenecekAracBilgisiGetir(int? aracID)
        {

            var aracBilgileri = (from a in db.Araclar.Where(a => a.AracID == aracID)
                                 join mo in db.Modeller on a.ModelID equals mo.ModelID
                                 join ma in db.Markalar on mo.MarkaID equals ma.MarkaID
                                 select new SecilenAracVM()
                                 {
                                     AracID = a.AracID,
                                     GrantiliMi = a.GarantiliMi,
                                     KaydedilenTarih = a.KaydedilenTarih,
                                     ModelID = a.ModelID,
                                     MarkaID = ma.MarkaID,
                                     PlakaID = a.PlakaID
                                 }).FirstOrDefault();

            var aracDetayBilgileri = (from ad in db.AracDetaylari.Where(a => a.AracID == aracID)
                                      join f in db.AracFotolari on ad.AracFotoID equals f.AracFotoID
                                      select new SecilenAracDetayVM()
                                      {
                                          AracID = ad.AracID,
                                          Aciklama = ad.Aciklama,
                                          GovdeTipiID = ad.GovdeTipID,
                                          KmBilgisi = ad.KmBilgisi,
                                          MotorGucu = ad.MotorGucu,
                                          MotorHacmi = ad.MotorHacmi,
                                          Yil = ad.Yıl,
                                          RenkID = ad.RenkID,
                                          VersiyonID = ad.VersiyonID,
                                          VitesTipiID = ad.VitesTipID,
                                          YakitTipiID = ad.YakitTipID,
                                          DonanimID = ad.OpsiyonelDonanimID
                                      }).FirstOrDefault();

            var bireyselAracBilgileri = (from b in db.BireyselKullaniciAracDetaylari.Where(a => a.AracID == aracID)
                                         select new SecilenBireyselAracVM()
                                         {
                                             AracID = b.AracID,
                                             BireyselAracStatuID = b.BireyselAracStatuID
                                         }).FirstOrDefault();


            BireyselAracDAL dal = new BireyselAracDAL();
            KullaniciDAL kullaniciDAL = new KullaniciDAL();

            var bireyselAracSahipleri = dal.BireyselAracSahipleriniGetir();
            var teklifFiyatlari = dal.TeklifFiyatlariniGetir();
            var onDegerlemeTutarlari = dal.OnDegerlemeTutarlariniGetir();

            string kullaniciAdiSoyadi = null;


            var teklifFiyati = teklifFiyatlari?.FirstOrDefault(a => a.AracID == aracID)?.Ucret ?? 0;


            var bireyselKullanicilar = kullaniciDAL.BireyselKullaniciGetir();
            var aracSahipID = bireyselKullanicilar == null ? 0 : bireyselAracSahipleri.FirstOrDefault(a => a.AracID == aracID).KullaniciID;
            if (aracSahipID != 0)
            {
                var bireyselKullanici = bireyselKullanicilar.FirstOrDefault(a => a.BireyselKullaniciID == aracSahipID);
                kullaniciAdiSoyadi = bireyselKullanici.Ad + " " + bireyselKullanici.Soyad;

            }

            var onDegerlemeTutari = onDegerlemeTutarlari?.FirstOrDefault(a => a.AracID == aracID)?.OnDegerlemeTutari ?? 0;


            return new BireyselAracGuncelleVM()
            {
                Arac = aracBilgileri,
                AracDetay = aracDetayBilgileri,
                BireyselArac = bireyselAracBilgileri,
                OnDegerlemeTutari = onDegerlemeTutari,
                TekliFiyati = teklifFiyati,
                AracSahibininAdi = kullaniciAdiSoyadi
            };

        }
    }
}