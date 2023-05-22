using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class OnDegerlemeTutar
    {
        [Key, ForeignKey("Arac")]
        public int AracID { get; set; }
        public decimal OnDegerlemeTutari { get; set; }
        public bool OnayliMi { get; set; }

        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
        public Arac Arac { get; set; }
    }
}