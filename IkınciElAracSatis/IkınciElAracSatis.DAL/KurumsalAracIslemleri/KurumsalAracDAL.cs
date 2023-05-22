using IkınciElAracSatis.CORE.Context;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkınciElAracSatis.DAL.KurumsalAracIslemleri
{
    public class KurumsalAracDAL
    {
        IkinciElAracSatisContext db = new IkinciElAracSatisContext();

        Arac arac = null;
        public bool AracEkle(DBAracEkleVM vm)
        {
            arac = db.Araclar.Add(new Arac()
            {
                GarantiliMi = vm.GarantiliMi,
                PlakaID = vm.PlakaID,
                ModelID = vm.ModelID,
                KaydedilenTarih = vm.KaydedilenTarih,
                AracNo = vm.AracNo,
                AdminKullaniciID = vm.AdminID
            });
            return db.SaveChanges() > 0;
        }

        public bool AracDetayEkle(DBAracDetayEkleVM vm)
        {
            db.AracDetaylari.Add(new AracDetay()
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
                AracFotoID = vm.FotoID,
                Aciklama = vm.Aciklama,
                GovdeTipID = vm.GovdeTipiID
            });

            return db.SaveChanges() > 0;
        }

        public bool KurumsalKullaniciAracDetayEkle(DBKurumsalKullaniciAracDetayEkle vm)
        {
            db.KurumsalKullaniciAracDetaylari.Add(new KurumsalKullaniciAracDetay()
            {
                RolID = vm.RolID,
                Fiyat = vm.Fiyat,
                ParaBirimID = vm.ParaBirimID,
                AracStatuID = vm.AracStatuID,
                AracID = arac.AracID
            });
            return db.SaveChanges() > 0;
        }



        public List<RolVM> MusteriRolBilgileriniGetir()
        {
            return (from k in db.Roller
                    where k.RolID != 1
                    select new RolVM()
                    {
                        RolID = k.RolID,
                        Rol = k.Rolu
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
