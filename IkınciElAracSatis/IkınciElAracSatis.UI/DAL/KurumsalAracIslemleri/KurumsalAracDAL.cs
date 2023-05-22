using IkınciElAracSatis.CORE.Context;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.DAL.DBKurumsalAracEkleme;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.Admin;
using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri;
using IkınciElAracSatis.UI.Models.VM.KullaniciRol;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IkınciElAracSatis.DAL.KurumsalAracIslemleri
{
    public class KurumsalAracDAL
    {
        IkinciElAracSatisContext db = new IkinciElAracSatisContext();

        Arac arac = null;
        public Arac AracEkle(DBAracEkleVM vm)
        {
            arac = db.Araclar.Add(new Arac()
            {
                GarantiliMi = vm.GarantiliMi,
                PlakaID = vm.PlakaID,
                ModelID = vm.ModelID,
                KaydedilenTarih = vm.KaydedilenTarih,
                AracNo = vm.AracNo,
                KullaniciID = vm.AdminID
            });
            int i = db.SaveChanges();
            return arac;
        }


        AracFoto aracFoto = null;
        public AracFoto AracFotolariEkle(FotoVM vm)
        {
            aracFoto = db.AracFotolari.Add(new AracFoto()
            {
                AracFotoID = vm.AracFotoID,
                AracFoto1 = vm.AracFoto1,
                AracFoto2 = vm.AracFoto2,
                AracFoto3 = vm.AracFoto3,
                AracFoto4 = vm.AracFoto4,
                AracFoto5 = vm.AracFoto5
            });
            int i = db.SaveChanges();
            return aracFoto;
        }

        public AracDetay AracDetayEkle(DBAracDetayEkleVM vm)
        {
            var aracDetay = db.AracDetaylari.Add(new AracDetay()
            {
                MotorHacmi = vm.MotorHacmi,
                MotorGucu = vm.MotorGucu,
                Yıl = vm.Yil,
                YakitTipID = vm.YakitTipiID,
                VitesTipID = vm.VitesTipiID,
                VersiyonID = vm.VersiyonID,
                KmBilgisi = vm.KmBilgisi,
                RenkID = vm.RenkID,
                OpsiyonelDonanimID = vm.DonanimID,
                AracFotoID = aracFoto.AracFotoID,
                Aciklama = vm.Aciklama,
                GovdeTipID = vm.GovdeTipiID,
                AracID = arac.AracID,
            });
            int i = db.SaveChanges();

          
            return aracDetay;
        }

 
        public List<AracTarihceVM> KurumsalAracTarihceGetir(int id)
        {
            return (from k in db.AracStatuLoglari
                    join s in db.AracStatuleri on k.AracStatuID equals s.AracStatuID
                    where k.AracID == id
                    select new AracTarihceVM()
                    {
                        AracID = k.AracID,
                        AracStatuID = k.AracStatuID,
                        DegistirilmeTarihi = k.KaydedilenTarih,
                        Statu = s.AracStatusu
                    }).ToList();
        }


        public KurumsalKullaniciAracDetay KurumsalKullaniciAracDetayEkle(DBKurumsalKullaniciAracDetayEkle vm)
        {
            var kurumsalAracDetay = db.KurumsalKullaniciAracDetaylari.Add(new KurumsalKullaniciAracDetay()
            {
                Fiyat = vm.Fiyat,
                ParaBirimID = vm.ParaBirimID,
                AracStatuID = vm.AracStatuID,
                AracID = arac.AracID,
                SirketID = vm.SirketID
            });
            int i = db.SaveChanges();
            return kurumsalAracDetay;
        }

        public bool DBKurumsalAracTarihceEkle(DBAracTarihceVM vm)
        {
            db.AracStatuLoglari.Add(new AracStatuLog()
            {
                 AracID = vm.AracID,
                 AracStatuID = vm.AracStatuID,
                 KaydedilenTarih = vm.DegistirilmeTarihi      
            });
          

            return db.SaveChanges() > 0;
        }

        public decimal AracUcretBilgisineGoreKomisyonGetir(Decimal aracUcret)
        {
            var belirlenenKomisyon = db.BelirlenenKomisyonlar.Where(a => a.AltLimit <= aracUcret && a.UstLimit >= aracUcret).FirstOrDefault();
            return belirlenenKomisyon.KomisyonUcret;
        }
        public int AracUcretBilgisineGoreKomisyonIDGetir(Decimal aracUcret)
        {
            var belirlenenKomisyon = db.BelirlenenKomisyonlar.Where(a => a.KomisyonUcret == aracUcret).FirstOrDefault();
            return belirlenenKomisyon.BelirlenenKomisyonID;
        }

        public bool DBKomisyonUcretEkle(KomisyonUcretVM vm)
        {
            
            db.Komisyonlar.Add(new Komisyon()
            {
                AracID = vm.AracID,
                BaslangicTarihi = vm.BaslangicTarihi,
                BitisTarihi = vm.BitisTarihi,
                BelirlenenKomisyonID = vm.BelirlenenKomisyonID,
            });

            return db.SaveChanges() > 0 ;

        }

        public bool DBNoterUcretEkle(NoterUcretVM vm)
        {
            db.NoterUcretleri.Add(new NoterUcret()
            {
                AracID = vm.AracID,
                BaslangicTarihi = vm.BaslangicTarihi,
                BitisTarihi = vm.BitisTarihi,
                Ucret = vm.Ucret,
                ParaBirimID = vm.ParaBirimID
            });


            return db.SaveChanges() > 0;
        }

        public NoterUcretVM NoterUcretiGetir(int aracID)
        {
            return (from n in db.NoterUcretleri
                    where n.AracID == aracID
                    select new NoterUcretVM()
                    {
                        BaslangicTarihi = n.BaslangicTarihi,
                        BitisTarihi = n.BitisTarihi,
                        ParaBirimID = n.ParaBirimID,
                        Ucret = n.Ucret,
                        AracID = aracID
                    }).FirstOrDefault();
        }

        public KomisyonUcretVM KomisyonUcretiGetir(int aracID)
        {
            return (from n in db.Komisyonlar
                    join k in db.BelirlenenKomisyonlar on n.BelirlenenKomisyonID equals k.BelirlenenKomisyonID
                    where n.AracID == aracID
                    select new KomisyonUcretVM()
                    {
                        AracID = n.AracID,
                        BaslangicTarihi = n.BaslangicTarihi,
                        BitisTarihi = n.BitisTarihi,
                        AracUcret = k.KomisyonUcret
                    }).FirstOrDefault();
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



        public int KullaniciAracStokMiktariGucenlle(int kurumsalAracDetayID)
        {
            var kurumsalAracDetayBilgisi = db.KurumsalKullaniciAracDetaylari.Find(kurumsalAracDetayID);
            var eskiKurumsalKullaniciBilgisi = db.KurumsalKullanicilar.FirstOrDefault(a => a.SirketID == kurumsalAracDetayBilgisi.SirketID);
            var eskiStokBilgisi = eskiKurumsalKullaniciBilgisi.AracStokMiktari + 1;
            eskiKurumsalKullaniciBilgisi.AracStokMiktari = eskiStokBilgisi;
            return db.SaveChanges();
        }

        public int KullaniciAracStokMiktariniAzalt(int kurumsalAracDetayID)
        {
            var kurumsalAracDetayBilgisi = db.KurumsalKullaniciAracDetaylari.Find(kurumsalAracDetayID);
            var eskiKurumsalKullaniciBilgisi = db.KurumsalKullanicilar.FirstOrDefault(a => a.SirketID == kurumsalAracDetayBilgisi.SirketID);
            var eskiStokBilgisi = eskiKurumsalKullaniciBilgisi.AracStokMiktari - 1;
            eskiKurumsalKullaniciBilgisi.AracStokMiktari = eskiStokBilgisi;
            return db.SaveChanges();
        }

        public int KurumsalAracDetayGuncelle(int sirketID, int kurumsalAracDetayID)
        {
            var kurumsalAracDetayBilgisi = db.KurumsalKullaniciAracDetaylari.Find(kurumsalAracDetayID);
            kurumsalAracDetayBilgisi.SirketID = sirketID;
            return db.SaveChanges();
        }

        public int AracDetayGuncelle(SecilenAracDetayVM vm, int id)
        {
            var eskiAracDetayBilgileri = db.AracDetaylari.Find(id);
            eskiAracDetayBilgileri.GovdeTipID = vm.GovdeTipiID;
            eskiAracDetayBilgileri.KmBilgisi = vm.KmBilgisi;
            eskiAracDetayBilgileri.MotorGucu = vm.MotorGucu;
            eskiAracDetayBilgileri.Aciklama = vm.Aciklama;
            eskiAracDetayBilgileri.MotorHacmi = vm.MotorHacmi;
            eskiAracDetayBilgileri.OpsiyonelDonanimID = vm.DonanimID;
            eskiAracDetayBilgileri.RenkID = vm.RenkID;
            eskiAracDetayBilgileri.Yıl = vm.Yil;
            eskiAracDetayBilgileri.YakitTipID = vm.YakitTipiID;
            eskiAracDetayBilgileri.VitesTipID = vm.VitesTipiID;
            eskiAracDetayBilgileri.VersiyonID = vm.VersiyonID;
            int i = db.SaveChanges();
            return i; 
        }


        public int KurumsalAracGuncelle(SecilenKurumsalAracVM vm, int id)
        {
            var eskiKurumsalArac = db.KurumsalKullaniciAracDetaylari.Find(id);
            eskiKurumsalArac.SirketID = vm.SirketID;
            eskiKurumsalArac.ParaBirimID = vm.ParaBirimID;
            eskiKurumsalArac.Fiyat = vm.Fiyat;
            eskiKurumsalArac.AracStatuID = vm.AracStatuID;
            return db.SaveChanges();
        }

        public int BireyselAracGuncelle(SecilenBireyselAracVM vm, int id)
        {
            var eskiBireyselArac = db.BireyselKullaniciAracDetaylari.Find(id);

            eskiBireyselArac.BireyselAracStatuID = vm.BireyselAracStatuID;

            return db.SaveChanges();
        }


        public List<MusteriRolVM> MusteriRolBilgileriniGetir()
        {
            return (from k in db.Roller
                    select new MusteriRolVM()
                    {
                        RolID = k.RolID,
                        Rol = k.KullaniciRol
                    }).ToList();
        }
        public List<AracStatuVM> AracStatuleriGetir()
        {
            return (from a in db.AracStatuleri
                    select new AracStatuVM()
                    {
                        AracStatuID = a.AracStatuID,
                        Statu = a.AracStatusu
                    }).ToList();
        }


        public List<ModelVM> ModelGetir()
        {
            return (from m in db.Modeller
                    select new ModelVM()
                    {
                        ModelID = m.ModelID,
                        ModelAdi = m.ModelAdi
                    }).ToList();
        }


        public List<PlakaVM> PlakaGetir()
        {
            return (from p in db.Plakalar
                    select new PlakaVM()
                    {
                        PlakaID = p.PlakaID,
                        Plaka = p.AracPlaka
                    }).ToList();
        }

        public List<MarkaVM> MarkaGetir()
        {
            return (from m in db.Markalar
                    select new MarkaVM()

                    {
                        MarkaID = m.MarkaID,
                        MarkaAdi = m.MarkaAdi
                    }).ToList();
        }
        public List<ParaBirimiVM> ParaBirimiGetir()
        {
            return (from P in db.ParaBirimleri
                    select new ParaBirimiVM()
                    {
                        ParaBirimiID = P.ParaBirimID,
                        ParaBirimi = P.ParaninBirimi
                    }).ToList();
        }

        public List<DonanimVM> DonanimGetir()
        {
            return (from d in db.OpsiyonelDonanimlari
                    select new DonanimVM()
                    {
                        DonanimID = d.OpsiyonelDonanimID,
                        Donanim = d.AracOpsiyonelDonanim
                    }).ToList();
        }

        public List<GovdeTipiVM> GovdeTipiGetir()
        {
            return (from g in db.GovdeTipleri
                    select new GovdeTipiVM()
                    {
                        GovdeTipiID = g.GovdeTipID,
                        GovdeTipi = g.AracGovdeTipi
                    }).ToList();
        }

        public List<RenkVM> RenkGetir()
        {
            return (from r in db.Renkler
                    select new RenkVM()
                    {
                        RenkID = r.RenkID,
                        Renk = r.AracRenk
                    }).ToList();
        }

        public List<SirketVM> SirketGetir()
        {
            return (from s in db.Sirketler
                    select new SirketVM()
                    {
                        SirketID = s.SirketID,
                        Sirket = s.SirketAdi
                    }).ToList();
        }

        public List<VersiyonVM> VersiyonGetir()
        {
            return (from v in db.Versiyonlar
                    select new VersiyonVM()
                    {
                        VersiyonID = v.VersiyonID,
                        Versiyon = v.AracVersiyon
                    }).ToList();
        }

        public List<VitesTipiVM> VitesTipiGetir()
        {
            return (from v in db.VitesTipleri
                    select new VitesTipiVM()
                    {
                        VitesTipiID = v.VitesTipID,
                        VitesTipi = v.AracVitesTipi
                    }).ToList();
        }

        public List<YakitTipiVM> YakitTipiGetir()
        {
            return (from y in db.YakitTipleri
                    select new YakitTipiVM()
                    {
                        YakitTipiID = y.YakitTipID,
                        YakitTipi = y.AracYakitTipi
                    }).ToList();
        }
    }
}
