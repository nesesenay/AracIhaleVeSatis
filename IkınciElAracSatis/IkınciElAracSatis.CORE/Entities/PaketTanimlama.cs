using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class PaketTanimlama
    {
        public int PaketID { get; set; }
        public Paket Paket { get; set; }
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}