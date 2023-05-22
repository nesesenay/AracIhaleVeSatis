using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracIhaleSahip
    {
        public int AracIhaleID { get; set; }
        public AracIhale AracIhale { get; set; }
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}