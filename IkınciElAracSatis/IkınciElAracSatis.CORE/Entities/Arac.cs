using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class Arac
    {
        [Key]
        public int AracID { get; set; }
        public int AracNo { get; set; }
        public DateTime KaydedilenTarih { get; set; }
        public bool GarantiliMi { get; set; }

        public int PlakaID { get; set; }
        public Plaka Plaka { get; set; }
        public int ModelID { get; set; }
        public Model Model { get; set; }
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }

        public List<BireyselAracSahip> BireyselAracSahipleri { get; set; }
        public IlanBilgi IlanBilgi { get; set; }
        public AracTarihce KurumsalAracTarihceleri { get; set; }
        public List<AracDurum> AracDurumlari { get; set; }
        public NoterUcret NoterUcret { get; set; }
        public List<KullaniciFavori> KurumsalKullaniciFavorileri { get; set; }
        public KurumsalKullaniciAracDetay KurumsalKullaniciAracDetay { get; set; }
        public BireyselKullaniciAracDetay BireyselKullaniciAracDetay { get; set; }
        public AracUcret AracUcret { get; set; }
        public List<BireyselAracTarihce> BireyselAracTarihceleri { get; set; }
        public IhaleFiyatBelirleme IhaleFiyatBelirleme { get; set; }
        public OnDegerlemeTutar BireyselOnDegerlemeTutari { get; set; }
        public List<IhaleFiyat> KurumsalIhaleFiyatlari { get; set; }
        public AracDetay AracDetay { get; set; }
        public Komisyon Komisyon { get; set; }
        public List<IhaleyeAracEkleme> IhaleyeAracEklemeler { get; set; }
        public List<AracStatuLog> AracStatuLoglari { get; set; }
    }
}