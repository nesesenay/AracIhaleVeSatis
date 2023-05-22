namespace IkınciElAracSatis.CORE.Migrations
{
    using IkınciElAracSatis.CORE.Entities;
    using IkinciElAracSatis.CORE.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IkınciElAracSatis.CORE.Context.IkinciElAracSatisContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IkınciElAracSatis.CORE.Context.IkinciElAracSatisContext context)
        {
            context.Kullanicilar.AddOrUpdate(a => a.KullaniciID,
               new Kullanici
               {
                   KullaniciID = 3,
                   Ad = "Neşe",
                   Soyad = "Şenay",
                   Email = "n@gmail.com",
                   Sifre = "1234",
                   RolID = 3,
                   Telefon = "(123) 123 12 12",
                   İl = "Muğla",
                   İlce = "Marmaris",
                   Adres = "Muğla Marmaris"
               },
                new Kullanici
                {
                    KullaniciID = 2,
                    Ad = "Serap",
                    Soyad = "Akdoğan",
                    Email = "s@gmail.com",
                    Sifre = "1234",
                    RolID = 1,
                    Telefon = "(123) 123 12 12",
                    İl = "İstanbul",
                    İlce = "Bağcılar",
                    Adres = "İstanbul Bağcılar"
                },
                new Kullanici
                {
                    KullaniciID = 1,
                    Ad = "İrem",
                    Soyad = "Demirci",
                    Email = "i@gmail.com",
                    Sifre = "1234",
                    RolID = 1,
                    Telefon = "(123) 123 12 12",
                    İl = "Denizli",
                    İlce = "Pamukkale",
                    Adres = "Denizli Pamukkale"
                });

            context.SaveChanges();

            var AdminKullanici = new AdminKullanici
            {
                KullaniciID = 1,
                HesapAktifMi = true,

            };
            context.AdminKullanicilari.AddOrUpdate(a => a.KullaniciID, AdminKullanici);
            context.SaveChanges();

            context.AracParcalari.AddOrUpdate(a => a.AracParcaID,
                new AracParca
                {
                    AracParcaID = 1,
                    AracParcaAdi = "Sağ arka çamurluk"
                },
                new AracParca
                {
                    AracParcaID = 2,
                    AracParcaAdi = "Arka kaput"
                },
                new AracParca
                {
                    AracParcaID = 3,
                    AracParcaAdi = "Sol arka çamurluk"
                },
                new AracParca
                {
                    AracParcaID = 4,
                    AracParcaAdi = "Sağ arka kapı"
                },
                new AracParca
                {
                    AracParcaID = 5,
                    AracParcaAdi = "Sağ ön kapı"
                },
                new AracParca
                {
                    AracParcaID = 6,
                    AracParcaAdi = "Tavan"
                },
                new AracParca
                {
                    AracParcaID = 7,
                    AracParcaAdi = "Sol arka kapı"
                },
                new AracParca
                {
                    AracParcaID = 8,
                    AracParcaAdi = "Sol ön kapı"
                },
                new AracParca
                {
                    AracParcaID = 9,
                    AracParcaAdi = "Sağ ön çamurluk"
                },
                new AracParca
                {
                    AracParcaID = 10,
                    AracParcaAdi = "Motor Kaputu"
                },
                new AracParca
                {
                    AracParcaID = 11,
                    AracParcaAdi = "Sol ön çamurluk"
                },
                new AracParca
                {
                    AracParcaID = 12,
                    AracParcaAdi = "Ön Tampon"
                },
                new AracParca
                {
                    AracParcaID = 13,
                    AracParcaAdi = "Arka Tampon"
                });

            context.SaveChanges();

            context.AracParcaDurumlari.AddOrUpdate(a => a.AracParcaDurumID,
                new AracParcaDurum
                {
                    AracParcaDurumID = 1,
                    ParcaDurumu = "Orjinal"
                },
                 new AracParcaDurum
                 {
                     AracParcaDurumID = 2,
                     ParcaDurumu = "Boyalı"
                 },
                new AracParcaDurum
                {
                    AracParcaDurumID = 3,
                    ParcaDurumu = "Değişmiş"
                });

            context.SaveChanges();

            context.AracStatuleri.AddOrUpdate(a => a.AracStatuID,
                new AracStatu
                {
                    AracStatuID = 1,
                    AracStatusu = "Giriş"
                },
                new AracStatu
                {
                    AracStatuID = 2,
                    AracStatusu = "Hemen Al Satışta"
                },
                new AracStatu
                {
                    AracStatuID = 3,
                    AracStatusu = "İhalede"
                },
                new AracStatu
                {
                    AracStatuID = 4,
                    AracStatusu = "Satış Komisyonu Tahsil Edildi"
                },
                new AracStatu
                {
                    AracStatuID = 5,
                    AracStatusu = "Ekspertiz Sonucu Bekleniyor"
                },
                new AracStatu
                {
                    AracStatuID = 6,
                    AracStatusu = "Ekspertiz Sonucu Alındı"
                },
                new AracStatu
                {
                    AracStatuID = 7,
                    AracStatusu = "Satıldı"
                },
                new AracStatu
                {
                    AracStatuID = 8,
                    AracStatusu = "Satış İptal"
                });

            context.SaveChanges();

            context.AracUcretTipleri.AddOrUpdate(a => a.AracUcretTipID,
                new AracUcretTip
                {
                    AracUcretTipID = 1,
                    UcretTipi = "Bireysel Teklif Fiyatı"
                },
                 new AracUcretTip
                 {
                     AracUcretTipID = 2,
                     UcretTipi = "Araç Provizyon Bedeli"
                 },
                  new AracUcretTip
                  {
                      AracUcretTipID = 3,
                      UcretTipi = "Araç Tarmer Bilgisi"
                  });

            context.SaveChanges();


            context.BireyselAracStatuleri.AddOrUpdate(a => a.BireyselAracStatuID,
                new BireyselAracStatu
                {
                    BireyselAracStatuID = 1,
                    AracStatu = "Giriş"
                },
                new BireyselAracStatu
                {
                    BireyselAracStatuID = 2,
                    AracStatu = "Ön Değerleme Verildi"
                },
                new BireyselAracStatu
                {
                    BireyselAracStatuID = 3,
                    AracStatu = "Ekspertiz Yapılıyor/Resmi Teklif Bekliyor"
                },
                new BireyselAracStatu
                {
                    BireyselAracStatuID = 4,
                    AracStatu = "Teklif Kabul Edildi"
                },
                new BireyselAracStatu
                {
                    BireyselAracStatuID = 5,
                    AracStatu = "Araç alındı"
                });

            context.SaveChanges();

            context.BireyselKullanicilar.AddOrUpdate(a => a.KullaniciID,
                new BireyselKullanici
                {
                    KullaniciID = 3,
                    KvkkIsaretliMi = true,

                });

            context.SaveChanges();

            context.IhaleStatuleri.AddOrUpdate(a => a.IhaleStatuID,
                new IhaleStatu
                {
                    IhaleStatuID = 1,
                    IhaleninSatusu = "Başlamadı"
                },
                new IhaleStatu
                {
                    IhaleStatuID = 2,
                    IhaleninSatusu = "Başladı"
                },
                new IhaleStatu
                {
                    IhaleStatuID = 3,
                    IhaleninSatusu = "Bitti"
                },
                new IhaleStatu
                {
                    IhaleStatuID = 4,
                    IhaleninSatusu = "İptal"
                });

            context.SaveChanges();


            context.KurumsalKullanicilar.AddOrUpdate(a => a.KullaniciID,
                new KurumsalKullanici
                {
                    KullaniciID = 2,
                    OnayliMi = true,
                    KvkkIsaretliMi = true,
                    AracStokMiktari = 0,
                    SirketBilgisi = "Araç Satış",
                    SirketID = 1,
                });

            context.SaveChanges();

            context.Sirketler.AddOrUpdate(a => a.SirketID,
                new Sirket
                {
                    SirketID = 1,
                    SirketAdi = "CarSales"
                },
                new Sirket
                {
                    SirketID = 2,
                    SirketAdi = "NesePlaza"
                }
                );

            context.SaveChanges();

            context.Paketler.AddOrUpdate(a => a.PaketID,
                new Paket
                {
                    PaketID = 1,
                    PaketAdi = "Altın"
                },
                new Paket
                {
                    PaketID = 2,
                    PaketAdi = "Bronz"
                },
                new Paket
                {
                    PaketID = 3,
                    PaketAdi = "Gümüş"
                });

            context.SaveChanges();

            context.PaketTanimlamalari.AddOrUpdate(
                new PaketTanimlama
                {
                    PaketID = 2,
                    KullaniciID = 2
                });

            context.SaveChanges();

            context.ParaBirimleri.AddOrUpdate(a => a.ParaBirimID,
                new ParaBirim
                {
                    ParaBirimID = 1,
                    ParaninBirimi = "TL"
                });

            context.SaveChanges();

            context.Plakalar.AddOrUpdate(a => a.PlakaID,
                new Plaka
                {
                    PlakaID = 1,
                    AracPlaka = "Türkiye (TR) Plakalı"
                });

            context.SaveChanges();

            context.Roller.AddOrUpdate(a => a.RolID,
                new Rol
                {
                    RolID = 1,
                    KullaniciRol = "Bireysel",
                },
                new Rol
                {
                    RolID = 2,
                    KullaniciRol = "Kurumsal",
                },
                new Rol
                {
                    RolID = 3,
                    KullaniciRol = "Admin",
                });

            context.SaveChanges();



            context.Markalar.AddOrUpdate(a => a.MarkaID,
                new Marka
                {
                    MarkaID = 1,
                    MarkaAdi = "BMW"
                },
                new Marka
                {
                    MarkaID = 2,
                    MarkaAdi = "Nissan"
                },
                new Marka
                {
                    MarkaID = 3,
                    MarkaAdi = "Lamborghini"
                },
                new Marka
                {
                    MarkaID = 4,
                    MarkaAdi = "Volvo"
                },
                new Marka
                {
                    MarkaID = 5,
                    MarkaAdi = "Ford"
                },
                new Marka
                {
                    MarkaID = 6,
                    MarkaAdi = "Wolkswagen"
                },
                new Marka
                {
                    MarkaID = 7,
                    MarkaAdi = "Tesla"
                });

            context.SaveChanges();

            context.Modeller.AddOrUpdate(a => a.ModelID,
                    new Model
                    {
                        ModelID = 1,
                        ModelAdi = "520i Comfort",
                        MarkaID = 1
                    },
                    new Model
                    {
                        ModelID = 2,
                        ModelAdi = "420d M Sport",
                        MarkaID = 1
                    },
                    new Model
                    {
                        ModelID = 3,
                        ModelAdi = " 1.0 DIG-T Tekna",
                        MarkaID = 2
                    },
                    new Model
                    {
                        ModelID = 4,
                        ModelAdi = " 1.5 e-Power Platinum Premium",
                        MarkaID = 2
                    },
                    new Model
                    {
                        ModelID = 5,
                        ModelAdi = "LP-610-4",
                        MarkaID = 3
                    },
                    new Model
                    {
                        ModelID = 6,
                        ModelAdi = " LP560-4",
                        MarkaID = 3
                    },
                    new Model
                    {
                        ModelID = 7,
                        ModelAdi = "2.0 D D5 Inscription",
                        MarkaID = 4
                    },
                    new Model
                    {
                        ModelID = 8,
                        ModelAdi = "1.6 D Premium",
                        MarkaID = 4
                    },
                    new Model
                    {
                        ModelID = 9,
                        ModelAdi = "1.5 TDCi Style",
                        MarkaID = 5
                    },
                    new Model
                    {
                        ModelID = 10,
                        ModelAdi = "1.6 Trend",
                        MarkaID = 5
                    },
                    new Model
                    {
                        ModelID = 11,
                        ModelAdi = "1.6 TDI BlueMotion R Line",
                        MarkaID = 6
                    },
                    new Model
                    {
                        ModelID = 12,
                        ModelAdi = "2.0 TDI Alltrack",
                        MarkaID = 6
                    },
                    new Model
                    {
                        ModelID = 13,
                        ModelAdi = "Long Range",
                        MarkaID = 7
                    },
                    new Model
                    {
                        ModelID = 14,
                        ModelAdi = "Performance",
                        MarkaID = 7
                    });

            context.SaveChanges();

            context.GovdeTipleri.AddOrUpdate(a => a.GovdeTipID,
                    new GovdeTip
                    {
                        GovdeTipID = 1,
                        AracGovdeTipi = "Cabrio"
                    },
                    new GovdeTip
                    {
                        GovdeTipID = 2,
                        AracGovdeTipi = "Coupe"
                    },
                    new GovdeTip
                    {
                        GovdeTipID = 3,
                        AracGovdeTipi = "Hatchback"
                    },
                    new GovdeTip
                    {
                        GovdeTipID = 4,
                        AracGovdeTipi = "Sedan"
                    },
                    new GovdeTip
                    {
                        GovdeTipID = 5,
                        AracGovdeTipi = "SUV"
                    });

            context.SaveChanges();

            context.YakitTipleri.AddOrUpdate(a => a.YakitTipID,
                    new YakitTip
                    {
                        YakitTipID = 1,
                        AracYakitTipi = "Benzin"
                    },
                    new YakitTip
                    {
                        YakitTipID = 2,
                        AracYakitTipi = "Dizel"
                    },
                    new YakitTip
                    {
                        YakitTipID = 3,
                        AracYakitTipi = "Hybrid"
                    },
                    new YakitTip
                    {
                        YakitTipID = 4,
                        AracYakitTipi = "Elektrik"
                    });

            context.SaveChanges();

            context.VitesTipleri.AddOrUpdate(a => a.VitesTipID,
                    new VitesTip
                    {
                        VitesTipID = 1,
                        AracVitesTipi = "Manuel"
                    },
                    new VitesTip
                    {
                        VitesTipID = 2,
                        AracVitesTipi = "Otomatik"
                    });

            context.SaveChanges();

            context.Renkler.AddOrUpdate(a => a.RenkID,
                    new Renk
                    {
                        RenkID = 1,
                        AracRenk = "Siyah"
                    },
                    new Renk
                    {
                        RenkID = 2,
                        AracRenk = "Füme"
                    },
                    new Renk
                    {
                        RenkID = 3,
                        AracRenk = "Beyaz"
                    },
                    new Renk
                    {
                        RenkID = 4,
                        AracRenk = "Kırmızı"
                    },
                    new Renk
                    {
                        RenkID = 5,
                        AracRenk = "Mavi"
                    });

            context.SaveChanges();

            context.Versiyonlar.AddOrUpdate(a => a.VersiyonID,
                    new Versiyon
                    {
                        VersiyonID = 1,
                        AracVersiyon = "Boş Paket"
                    },
                    new Versiyon
                    {
                        VersiyonID = 2,
                        AracVersiyon = "Full Paket"
                    });

            context.SaveChanges();

            context.OpsiyonelDonanimlari.AddOrUpdate(a => a.OpsiyonelDonanimID,
                    new OpsiyonelDonanim
                    {
                        OpsiyonelDonanimID = 1,
                        AracOpsiyonelDonanim = "Şerit Takip Sistemi Var"
                    },
                    new OpsiyonelDonanim
                    {
                        OpsiyonelDonanimID = 2,
                        AracOpsiyonelDonanim = "Şerit Takip Sistemi Yok"
                    });

            context.SaveChanges();
        }
    }
}
