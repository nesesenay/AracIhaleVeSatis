using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkınciElAracSatis.CORE.Context
{
    public class IkinciElAracSatisContext : DbContext
    {
        public IkinciElAracSatisContext() : base()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Rol>()
           .HasMany<Kullanici>(c => c.Kullanicilar)
           .WithRequired(o => o.Rol)
           .HasForeignKey(o => o.RolID)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
          .HasMany<AracIhale>(c => c.AracIhaleleri)
          .WithRequired(o => o.Kullanici)
          .HasForeignKey(o => o.KullaniciID)
          .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
         .HasMany<Arac>(c => c.Araclar)
         .WithRequired(o => o.Kullanici)
         .HasForeignKey(o => o.KullaniciID)
         .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sirket>()
             .HasMany<AracIhale>(c => c.AracIhaleleri)
             .WithRequired(o => o.Sirket)
             .HasForeignKey(o => o.SirketID)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<BireyselAracSahip>()
                 .HasKey(a => new {
                     a.AracID,
                     a.KullaniciID
                 });

            modelBuilder.Entity<PaketTanimlama>()
                .HasKey(a => new {
                    a.PaketID,
                    a.KullaniciID
                });

            modelBuilder.Entity<PaketTanimlama>()
                .HasRequired(a => a.Kullanici)
                .WithMany(a => a.PaketTanimlamalari)
                .HasForeignKey(a => a.KullaniciID);

            modelBuilder.Entity<PaketTanimlama>()
               .HasRequired(a => a.Paket)
               .WithMany(a => a.PaketTanimlamalari)

               .HasForeignKey(a => a.PaketID);

            modelBuilder.Entity<AracIhaleSahip>()
                .HasKey(a => new {
                    a.KullaniciID,
                    a.AracIhaleID
                });

         

            modelBuilder.Entity<AracIhaleSahip>()
                .HasRequired(a => a.Kullanici)
                .WithMany(a => a.AracIhaleSahipleri)
                .HasForeignKey(a => a.KullaniciID);

            modelBuilder.Entity<AracIhaleSahip>()
               .HasRequired(a => a.AracIhale)
               .WithMany(a => a.AracIhaleSahipleri)
               .HasForeignKey(a => a.AracIhaleID);



            modelBuilder.Entity<IhaleyeAracEkleme>()
              .HasKey(a => new {
                  a.AracID,
                  a.AracIhaleID
              });

            modelBuilder.Entity<IhaleyeAracEkleme>()
              .HasRequired(a => a.Arac)
              .WithMany(a => a.IhaleyeAracEklemeler)
              .HasForeignKey(a => a.AracID)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<IhaleyeAracEkleme>()
                .HasRequired(a => a.AracIhale)
                .WithMany(a => a.IhaleyeAracEklemeler)
                .HasForeignKey(a => a.AracIhaleID)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<AracStatuLog>()
             .HasKey(a => new {
                 a.AracID,
                 a.AracStatuID
             });

            modelBuilder.Entity<AracStatuLog>()
              .HasRequired(a => a.Arac)
              .WithMany(a => a.AracStatuLoglari)
              .HasForeignKey(a => a.AracID)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<AracStatuLog>()
                .HasRequired(a => a.AracStatu)
                .WithMany(a => a.AracStatuLoglari)
                .HasForeignKey(a => a.AracStatuID)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<BireyselAracTarihce>()
            .HasKey(a => new {
                a.AracID,
                a.BireyselAracStatuID
            });

            modelBuilder.Entity<BireyselAracTarihce>()
              .HasRequired(a => a.Arac)
              .WithMany(a => a.BireyselAracTarihceleri)
              .HasForeignKey(a => a.AracID)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<BireyselAracTarihce>()
                .HasRequired(a => a.BireyselAracStatu)
                .WithMany(a => a.BireyselAracTarihceleri)
                .HasForeignKey(a => a.BireyselAracStatuID)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AdminKullanici> AdminKullanicilari { get; set; }
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<AracDetay> AracDetaylari { get; set; }
        public DbSet<AracDurum> AracDurumlari { get; set; }
        public DbSet<AracFoto> AracFotolari { get; set; }
        public DbSet<AracIhale> AracIhaleleri { get; set; }
        public DbSet<AracParca> AracParcalari { get; set; }
        public DbSet<AracParcaDurum> AracParcaDurumlari { get; set; }
        public DbSet<AracStatu> AracStatuleri { get; set; }
        public DbSet<AracUcret> AracUcretleri { get; set; }
        public DbSet<AracUcretTip> AracUcretTipleri { get; set; }
        public DbSet<BireyselAracSahip> BireyselAracSahipleri { get; set; }
        public DbSet<BireyselAracStatu> BireyselAracStatuleri { get; set; }
        public DbSet<BireyselAracTarihce> BireyselAracTarihceleri { get; set; }
        public DbSet<BireyselKullanici> BireyselKullanicilar { get; set; }
        public DbSet<BireyselKullaniciAracDetay> BireyselKullaniciAracDetaylari { get; set; }
        public DbSet<OnDegerlemeTutar> BireyselOnDegerlemeTutarlari { get; set; }
        public DbSet<GovdeTip> GovdeTipleri { get; set; }
        public DbSet<IhaleFiyatBelirleme> IhaleFiyatBelirlemeleri { get; set; }
        public DbSet<IhaleStatu> IhaleStatuleri { get; set; }
        public DbSet<IhaleyeAracEkleme> IhaleyeAracEklemeleri { get; set; }
        public DbSet<IlanBilgi> IlanBilgileri { get; set; }
        public DbSet<Komisyon> Komisyonlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<AracIhaleSahip> KurumsalAracIhaleleri { get; set; }
        public DbSet<AracTarihce> KurumsalAracTarihceleri { get; set; }
        public DbSet<IhaleFiyat> KurumsalIhaleFiyatlari { get; set; }
        public DbSet<KurumsalKullanici> KurumsalKullanicilar { get; set; }
        public DbSet<KurumsalKullaniciAracDetay> KurumsalKullaniciAracDetaylari { get; set; }
        public DbSet<KullaniciFavori> KurumsalKullaniciFavorileri { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Model> Modeller { get; set; }
        public DbSet<NoterUcret> NoterUcretleri { get; set; }
        public DbSet<OpsiyonelDonanim> OpsiyonelDonanimlari { get; set; }
        public DbSet<Paket> Paketler { get; set; }
        public DbSet<PaketTanimlama> PaketTanimlamalari { get; set; }
        public DbSet<ParaBirim> ParaBirimleri { get; set; }
        public DbSet<Plaka> Plakalar { get; set; }
        public DbSet<Renk> Renkler { get; set; }
        public DbSet<Sirket> Sirketler { get; set; }
        public DbSet<Versiyon> Versiyonlar { get; set; }
        public DbSet<VitesTip> VitesTipleri { get; set; }
        public DbSet<YakitTip> YakitTipleri { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<BelirlenenKomisyon> BelirlenenKomisyonlar { get; set; }
        public DbSet<AracStatuLog> AracStatuLoglari { get; set; }
    }
}
