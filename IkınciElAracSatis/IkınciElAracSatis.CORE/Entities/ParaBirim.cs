using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class ParaBirim
    {
        [Key]
        public int ParaBirimID { get; set; }
        [Required]
        [StringLength(10)]
        public string ParaninBirimi { get; set; }

        public List<NoterUcret> NoterUcretleri { get; set; }
        public List<KurumsalKullaniciAracDetay> KurumsalKullaniciAracDetaylari { get; set; }
        public List<AracUcret> AracUcretleri { get; set; }
        public List<IhaleFiyatBelirleme> IhaleFiyatBelirlemeleri { get; set; }
        public List<IhaleFiyat> KurumsalIhaleFiyatlari { get; set; }
        public List<BelirlenenKomisyon> BelirlenenKomisyonlar { get; set; }
    }
}