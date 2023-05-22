using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class KurumsalKullanici
    {
        [Key, ForeignKey("Kullanici")]
        public int KullaniciID { get; set; }
        public bool OnayliMi { get; set; }
        [Required]
        public bool KvkkIsaretliMi { get; set; }
        [Required]
        public int AracStokMiktari { get; set; }
        [StringLength(200)]
        public string SirketBilgisi { get; set; }
        public int SirketID { get; set; }




        [ForeignKey("SirketID")]
        public Sirket Sirket { get; set; }

        public Kullanici Kullanici { get; set; }



    }
}