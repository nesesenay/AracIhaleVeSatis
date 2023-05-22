using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AdminKullanici
    {
        [Key, ForeignKey("Kullanici")]
        public int KullaniciID { get; set; }
        public bool HesapAktifMi { get; set; }
        [Required]
        [StringLength(30)]
       

        public Kullanici Kullanici { get; set; }
    }
}