using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class KullaniciFavori
    {
        [Key]
        public int KurumsalKullaniciFavoriID { get; set; }

        public DateTime Tarih { get; set; }
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
        public int AracID { get; set; }
        public Arac Arac { get; set; }
    }
}