using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class Sirket
    {
        [Key]
        public int SirketID { get; set; }
        [Required]
        [StringLength(60)]
        public string SirketAdi { get; set; }

        public List<KurumsalKullaniciAracDetay> KurumsalKullaniciAracDetaylari { get; set; }
        public List<AracIhale> AracIhaleleri { get; set; }
    }
}