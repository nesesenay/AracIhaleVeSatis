using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracTarihce
    {
        [Key, ForeignKey("Arac")]
        public int AracID { get; set; }
        public DateTime DegistirilmeTarihi { get; set; }


        public Arac Arac { get; set; }
        public int AracStatuID { get; set; }
        public AracStatu AracStatu { get; set; }
      
    }
}