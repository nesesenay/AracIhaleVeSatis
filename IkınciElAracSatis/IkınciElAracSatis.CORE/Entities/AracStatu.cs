using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracStatu
    {
        [Key]
        public int AracStatuID { get; set; }
        [Required]
        [StringLength(50)]
        public string AracStatusu { get; set; }

        public List<KurumsalKullaniciAracDetay> KurumsalKullaniciAracDetaylari { get; set; }
        public List<AracStatuLog> AracStatuLoglari { get; set; }
    }
}