using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace IkınciElAracSatis.UI.DAL.KullaniciAracEkleme
{
    public class KurumsalKullaniciAracEkleDAL
    {

        IkinciElAracSatisContext db = new IkinciElAracSatisContext();

      
        public KurumsalAracOzellikleriVM KurumsalKullaniciAracEkle()
        {
            KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();

            List<ModelVM> modeller = kurumsalArac.ModelGetir();
            List<MarkaVM> markalar = kurumsalArac.MarkaGetir();
            List<DonanimVM> donanimlar = kurumsalArac.DonanimGetir();
            List<GovdeTipiVM> govdeTipleri = kurumsalArac.GovdeTipiGetir();
            List<RenkVM> renkler = kurumsalArac.RenkGetir();
            List<SirketVM> sirketler = kurumsalArac.SirketGetir();
            List<VersiyonVM> versiyonlar = kurumsalArac.VersiyonGetir();
            List<VitesTipiVM> vitesTipleri = kurumsalArac.VitesTipiGetir();
            List<YakitTipiVM> yakitTipleri = kurumsalArac.YakitTipiGetir();
            List<PlakaVM> palakalar = kurumsalArac.PlakaGetir();
            List<ParaBirimiVM> paraBirimleri = kurumsalArac.ParaBirimiGetir();
            List<AracStatuVM> aracStatuleri = kurumsalArac.AracStatuleriGetir();

            var aracEkle = new AracEkleVM()
            {
                Plakalar = palakalar.Select(a => new SelectListItem()
                {
                    Text = a.Plaka,
                    Value = a.PlakaID.ToString()
                }).ToList(),
                Modeller = modeller.Select(a => new SelectListItem()
                {
                    Text = a.ModelAdi,
                    Value = a.ModelID.ToString()
                }).ToList(),
                Markalar = markalar.Select(a => new SelectListItem()
                {
                    Text = a.MarkaAdi,
                    Value = a.MarkaID.ToString()
                }).ToList()
            };

            var aracDetayEkle = new AracDetayEkleVM()
            {
                Donanimlar = donanimlar.Select(a => new SelectListItem()
                {
                    Text = a.Donanim,
                    Value = a.DonanimID.ToString()
                }).ToList(),
                GovdeTipleri = govdeTipleri.Select(a => new SelectListItem()
                {
                    Text = a.GovdeTipi,
                    Value = a.GovdeTipiID.ToString()
                }).ToList(),
                Renkler = renkler.Select(a => new SelectListItem()
                {
                    Text = a.Renk,
                    Value = a.RenkID.ToString()
                }).ToList(),
                Versiyonlar = versiyonlar.Select(a => new SelectListItem()
                {
                    Text = a.Versiyon,
                    Value = a.VersiyonID.ToString()
                }).ToList(),
                VitesTipleri = vitesTipleri.Select(a => new SelectListItem()
                {
                    Text = a.VitesTipi,
                    Value = a.VitesTipiID.ToString()
                }).ToList(),
                YakitTipleri = yakitTipleri.Select(a => new SelectListItem()
                {
                    Text = a.YakitTipi,
                    Value = a.YakitTipiID.ToString()
                }).ToList(),
            };

            var kurumsalKullaniciAracDetayEkle = new KurumsalKullaniciAracDetayEkleVM()
            {
                ParaBirimleri = paraBirimleri.Select(a => new SelectListItem()
                {
                    Text = a.ParaBirimi,
                    Value = a.ParaBirimiID.ToString()
                }).ToList(),
                AracStatuleri = aracStatuleri.Select(a => new SelectListItem()
                {
                    Text = a.Statu,
                    Value = a.AracStatuID.ToString()
                }).ToList(),
                Sirketler = sirketler.Select(a => new SelectListItem()
                {
                    Text = a.Sirket,
                    Value = a.SirketID.ToString()
                }).ToList()
              
            };

            return new KurumsalAracOzellikleriVM()
            {
                KurumsalKullaniciAracDetaylari = kurumsalKullaniciAracDetayEkle,
                Araclar = aracEkle,
                AracDetaylari = aracDetayEkle,
            };
        } 
    }
}