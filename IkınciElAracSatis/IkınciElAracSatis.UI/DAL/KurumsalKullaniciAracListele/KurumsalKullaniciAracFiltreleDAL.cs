using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.CORE.Entities;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.Admin;
using IkınciElAracSatis.UI.Models.VM.DBKurumsalAracEkle;
using IkınciElAracSatis.UI.Models.VM.KullaniciRol;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracFiltrele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.DAL.KurumsalKullaniciAracListele
{
    public class KurumsalKullaniciAracFiltreleDAL
    {

        KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();
        IkinciElAracSatisContext db = new IkinciElAracSatisContext();


        public KurumsalAracGuncelleVM GuncellenecekAracBilgisiGetir(int? aracID)
        {
           
            var aracBilgileri = (from a in db.Araclar.Where(a => a.AracID == aracID)
                                 join kad in db.KurumsalKullaniciAracDetaylari on a.AracID equals kad.AracID
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

            var kurumsalAracBilgileri = (from kad in db.KurumsalKullaniciAracDetaylari.Where(a => a.AracID == aracID)
                                         select new SecilenKurumsalAracVM()
                                         {
                                             Fiyat = kad.Fiyat,
                                             ParaBirimID = kad.ParaBirimID,
                                             AracStatuID = kad.AracStatuID,
                                             SirketID = kad.SirketID
                                         }).FirstOrDefault();


            return new KurumsalAracGuncelleVM()
            {
                Arac = aracBilgileri,
                AracDetay = aracDetayBilgileri,
                KurumsalArac = kurumsalAracBilgileri
            };

        }

        public AracListeleVM KurumsalAracGetir()
        {
            

            List<ModelVM> modeller = kurumsalArac.ModelGetir();
            List<MarkaVM> markalar = kurumsalArac.MarkaGetir();
            List<AracStatuVM> aracStatuleri = kurumsalArac.AracStatuleriGetir();
            List<MusteriRolVM> musteriRolleri = kurumsalArac.MusteriRolBilgileriniGetir();


            var aracFiltrelemeVM =  new AracFiltreleVM()
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
                MusteriRolleri = musteriRolleri.Select(a => new SelectListItem()
                {
                    Text = a.Rol,
                    Value = a.RolID.ToString()
                }).ToList(),
                AracStatuleri = aracStatuleri.Select(a => new SelectListItem()
                {
                    Text = a.Statu,
                    Value = a.AracStatuID.ToString()
                }).ToList()
            };

           

            List<AracGetirVM> aracGetirVM = (from a in db.Araclar
                                             join m in db.Modeller on a.ModelID equals m.ModelID
                                             join ma in db.Markalar on m.MarkaID equals ma.MarkaID
                                             join kad in db.KurumsalKullaniciAracDetaylari on a.AracID equals kad.AracID
                                             join s in db.Sirketler on kad.SirketID equals s.SirketID
                                             join k in db.KurumsalKullanicilar on s.SirketID equals k.SirketID
                                             join ku in db.Kullanicilar on a.KullaniciID equals ku.KullaniciID
                                             join st in db.AracStatuleri on kad.AracStatuID equals st.AracStatuID
                                             join r in db.Roller on ku.RolID equals r.RolID
                                             where a.AracID == kad.AracID
                                             group new { a, m, ma, kad, s, k, st, r, ku } by a.AracID into aracDetay
                                             select new AracGetirVM()
                                             {
                                                 AracID = aracDetay.Key,
                                                 AracNo = aracDetay.FirstOrDefault().a.AracNo,
                                                 ModelID = aracDetay.FirstOrDefault().m.ModelID,
                                                 MarkaID = aracDetay.FirstOrDefault().ma.MarkaID,
                                                 AdminID = aracDetay.FirstOrDefault().a.KullaniciID,
                                                 KaydedilenTarih = aracDetay.FirstOrDefault().a.KaydedilenTarih,
                                                 KurumsalStatuID = aracDetay.FirstOrDefault().kad.AracStatuID,
                                                 RolID = aracDetay.FirstOrDefault().ku.RolID,
                                                 ModelAdi = aracDetay.FirstOrDefault().m.ModelAdi,
                                                 MarkaAdi = aracDetay.FirstOrDefault().ma.MarkaAdi,
                                                 AdminAdi = aracDetay.FirstOrDefault().ku.Ad,
                                                 Rol = aracDetay.FirstOrDefault().r.KullaniciRol,
                                                 KurumsalStatu = aracDetay.FirstOrDefault().st.AracStatusu
                                             }).ToList();


            return new AracListeleVM
            {
                AracFiltreleri = aracFiltrelemeVM,
                KurumsalAraclar = aracGetirVM
            };
        }
    }
}