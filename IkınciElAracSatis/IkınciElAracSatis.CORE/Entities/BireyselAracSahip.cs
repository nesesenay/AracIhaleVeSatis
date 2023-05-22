using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class BireyselAracSahip
    {
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
        public int AracID { get; set; }
        public Arac Arac { get; set; }
    }
}