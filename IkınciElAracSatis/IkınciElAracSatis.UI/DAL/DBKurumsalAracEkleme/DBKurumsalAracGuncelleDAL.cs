using IkınciElAracSatis.UI.Models.VM.Admin;
using IkınciElAracSatis.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using System.Transactions;
using IkınciElAracSatis.UI.Models.VM.KullaniciRol;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using IkınciElAracSatis.UI.DAL.KurumsalKullaniciAracListele;

namespace IkınciElAracSatis.UI.DAL.Admin
{
    public class DBKurumsalAracGuncelleDAL
    {
     

        public void AracBilgileriniGuncelle(KurumsalAracOzellikleriVM vm, int aracID)
        {


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();


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

                    var dbKurumsalAracDetayEkle = kurumsalArac.KurumsalAracGuncelle(new SecilenKurumsalAracVM()
                    {
                        SirketID = vm.KurumsalKullaniciAracDetaylari.SirketID,
                        Fiyat = vm.KurumsalKullaniciAracDetaylari.Fiyat,
                        ParaBirimID = vm.KurumsalKullaniciAracDetaylari.ParaBirimID,
                        AracStatuID = vm.KurumsalKullaniciAracDetaylari.AracStatuID,
                    }, aracID);

                    var aracBilgileri = new KurumsalKullaniciAracFiltreleDAL().GuncellenecekAracBilgisiGetir(aracID);
                    var aracStatuID = aracBilgileri.KurumsalArac.AracStatuID;


                    var statuLog = new DBAracTarihceVM()
                    {
                        AracID = aracID ,
                        AracStatuID = aracStatuID
                    };

                    var eklenenKurumsalAracTarihce = new KurumsalAracDAL().DBKurumsalAracTarihceEkle(statuLog);

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