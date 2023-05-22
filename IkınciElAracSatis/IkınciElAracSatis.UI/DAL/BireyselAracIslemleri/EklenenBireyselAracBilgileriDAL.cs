using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.DAL.Kullanici;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.DAL.BireyselAracIslemleri
{
    public class EklenenBireyselAracBilgileriDAL
    {


        IkinciElAracSatisContext db = new IkinciElAracSatisContext();


        public BireyselAracOzellikleriVM EklenenBireyselKullaniciAracBilgileriniGetir()
        {
            KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();
            BireyselAracDAL bireyselArac = new BireyselAracDAL();

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
            List<BireyselAracStatuVM> bireyselAracStatuleri = bireyselArac.BireyselAracStatuleriniGetir();


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

            var bireyselKullaniciAracDetayEkle = new BireyselKullaniciAracDetayEkleVM()
            {
                AracStatuleri = bireyselAracStatuleri.Select(a => new SelectListItem()
                {
                    Text = a.AracStatu,
                    Value = a.BireyselAracStatuID.ToString()
                }).ToList(),
            };

           


            return new BireyselAracOzellikleriVM()
            {
                AracDetaylari = aracDetayEkle,
                Araclar = aracEkle,
                BireyselKullaniciAracDetaylari = bireyselKullaniciAracDetayEkle,
            };
        }
    }
}