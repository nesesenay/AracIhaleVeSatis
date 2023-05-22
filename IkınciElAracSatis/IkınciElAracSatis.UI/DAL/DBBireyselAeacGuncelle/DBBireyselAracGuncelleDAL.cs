using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.DAL.KurumsalKullaniciAracListele;
using IkınciElAracSatis.UI.Models.VM.KullaniciRol;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using IkınciElAracSatis.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri;
using IkınciElAracSatis.UI.DAL.BireyselAracIslemleri;
using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;

namespace IkınciElAracSatis.UI.DAL.DBBireyselAeacGuncelle
{
    public class DBBireyselAracGuncelleDAL
    {
        public void AracBilgileriniGuncelle(BireyselAracOzellikleriVM vm, int aracID)
        {


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();
                    BireyselAracDAL bireyselArac = new BireyselAracDAL();


                    var dbAracEkle = kurumsalArac.AracGuncelle(new SecilenAracVM()
                    {
                        MarkaID = vm.Araclar.MarkaID,
                        ModelID = vm.Araclar.ModelID,
                        GrantiliMi = vm.Araclar.GarantiliMi,
                        PlakaID = vm.Araclar.PlakaID,
                    }, aracID);



                    var dbAracDetayEkle = kurumsalArac.AracDetayGuncelle(new SecilenAracDetayVM()
                    {
                        MotorGucu = vm.AracDetaylari.MotorGucu,
                        MotorHacmi = vm.AracDetaylari.MotorHacmi,
                        GovdeTipiID = vm.AracDetaylari.GovdeTipiID,
                        Yil = vm.AracDetaylari.Yil,
                        YakitTipiID = vm.AracDetaylari.YakitTipiID,
                        VitesTipiID = vm.AracDetaylari.VitesTipiID,
                        VersiyonID = vm.AracDetaylari.VersiyonID,
                        KmBilgisi = vm.AracDetaylari.KmBilgisi,
                        RenkID = vm.AracDetaylari.RenkID,
                        DonanimID = vm.AracDetaylari.DonanimID,
                        Aciklama = vm.AracDetaylari.Aciklama,
                    }, aracID);

                    var dbKurumsalAracDetayEkle = kurumsalArac.BireyselAracGuncelle(new SecilenBireyselAracVM()
                    {
                        BireyselAracStatuID = vm.BireyselKullaniciAracDetaylari.BireyselAracStatuID
                    }, aracID);

                    var aracBilgileri = new BireyselKullaniciAracListelemDAL().GuncellenecekAracBilgisiGetir(aracID);
                    var aracStatuID = aracBilgileri.BireyselArac.BireyselAracStatuID;


                    var tarihce = new DBBireyselAracTarihceVM()
                    {
                        AracID = aracID,
                        BireyselAracStatuID = aracStatuID
                    };

                    var tarihceler = bireyselArac.BireyselAracTarihceGetir(aracID);

                    var eklenecekTarihceID = tarihceler?.FirstOrDefault(a => a.AracStatuID == tarihce.BireyselAracStatuID)?.AracStatuID ?? 0;

                    if (eklenecekTarihceID == 0)
                    {
                        var eklenenBireyselAracTarihce = bireyselArac.DBBireyselTarihceEkle(tarihce);
                    }

                    var aracSahipleri = bireyselArac.BireyselAracSahipleriniGetir();
                    var secilenAracSahibi = aracSahipleri.FirstOrDefault(a => a.AracID == aracID);

                    var onDegerlemeTutari = new OnDegerlemeFiyatVM()
                    {
                        AracID = aracID,
                        KullaniciID = secilenAracSahibi.KullaniciID,
                        OnDegerlemeTutari = vm.OnDegerlemeTutari
                    };

                    var onDegerlemeTutarlari = bireyselArac.OnDegerlemeTutarlariniGetir();

                    if (onDegerlemeTutarlari?.FirstOrDefault(a => a.AracID == aracID) == null)
                    {
                        var eklenenOnDegerelemeTutari = bireyselArac.OnDegerlemeTutariEkle(onDegerlemeTutari);
                    }
                    else
                    {
                        var guncellenenOnDegerlemeTutari = bireyselArac.OnDegerlemeTutariGuncelle(aracID, onDegerlemeTutari);
                    }


                    var teklifFiyati = new TeklifFiyatiUcretVM()
                    {
                        AracID = aracID,
                        Ucret = vm.TekliFiyati
                    };

                    var teklifFiyatlari = bireyselArac.TeklifFiyatlariniGetir();

                    if (teklifFiyatlari?.FirstOrDefault(a => a.AracID == aracID) == null)
                    {
                        var eklenenTeklifFiyati = bireyselArac.TeklifFiyatiEkle(teklifFiyati);
                    }
                    else
                    {
                        var guncellenenTeklifFiyati = bireyselArac.TeklifFiyatiGuncelle(aracID, teklifFiyati);
                    }

                    var guncelenenenAracSahibi = bireyselArac.BireyselAracSahipGuncelle(aracID,vm.AracSahibininAdi);

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                }
            }
        }
    }
}