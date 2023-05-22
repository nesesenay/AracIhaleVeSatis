using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.CORE.Entities;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.DBKurumsalAracEkle;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;



namespace IkınciElAracSatis.UI.DAL.DBKurumsalAracEkleme
{
    public class DBKurumsalKullaniciAracEkleDAL
    {
        public void DBKurumsalKullaniciAracEkle(KurumsalAracOzellikleriVM vm, int kullaniciID, string[] resimler)
        {
            IkinciElAracSatisContext db = new IkinciElAracSatisContext();


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();


                        var dbAracEkle = kurumsalArac.AracEkle(new DBAracEkleVM()
                        {
                            ModelID = vm.Araclar.ModelID,
                            PlakaID = vm.Araclar.PlakaID,
                            GarantiliMi = vm.Araclar.GarantiliMi,
                            KaydedilenTarih = DateTime.Now,
                            AracNo = vm.Araclar.AracNo,
                            AdminID = (int)kullaniciID,
                            MarkaID = vm.Araclar.MarkaID
                        });

                  

                    var aracFotoEkle = kurumsalArac.AracFotolariEkle(new FotoVM()
                        {
                            AracFoto1 = resimler[0],
                            AracFoto2 = resimler[1],
                            AracFoto3 = resimler[2],
                            AracFoto4 = resimler[3],
                            AracFoto5 = resimler[4]                        
                        });



                        var dbAracDetayEkle = kurumsalArac.AracDetayEkle(new DBAracDetayEkleVM()
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
                        });


                    var dbKurumsalAracDetayEkle = kurumsalArac.KurumsalKullaniciAracDetayEkle(new DBKurumsalKullaniciAracDetayEkle()
                        {
                            SirketID = vm.KurumsalKullaniciAracDetaylari.SirketID,
                            Fiyat = vm.KurumsalKullaniciAracDetaylari.Fiyat,
                            ParaBirimID = vm.KurumsalKullaniciAracDetaylari.ParaBirimID,
                            AracStatuID = vm.KurumsalKullaniciAracDetaylari.AracStatuID,
                        });

                    var statuLog = new DBAracTarihceVM()
                    {
                        AracID = dbKurumsalAracDetayEkle.AracID,
                        AracStatuID = dbKurumsalAracDetayEkle.AracStatuID
                    };



                    var eklenenKurumsalAracTarihce = new KurumsalAracDAL().DBKurumsalAracTarihceEkle(statuLog);

                    new KurumsalAracDAL().KullaniciAracStokMiktariGucenlle(dbKurumsalAracDetayEkle.AracID);

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