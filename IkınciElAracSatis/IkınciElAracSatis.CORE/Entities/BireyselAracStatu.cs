using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class BireyselAracStatu
    {
        [Key]
        public int BireyselAracStatuID { get; set; }
        [Required]
        [StringLength(60)]
        public string AracStatu { get; set; }

        public List<BireyselKullaniciAracDetay> BireyselKullaniciAracDetaylari { get; set; }
        public List<BireyselAracTarihce> BireyselAracTarihceleri { get; set; }
    }
}