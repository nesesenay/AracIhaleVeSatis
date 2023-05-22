using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class BireyselKullaniciAracDetay
    {
        [Key, ForeignKey("Arac")]
        public int AracID { get; set; }

        public int BireyselAracStatuID { get; set; }
        public BireyselAracStatu BireyselAracStatu { get; set; }


        public Arac Arac { get; set; }
    }
}