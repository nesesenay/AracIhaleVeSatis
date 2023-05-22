using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class BireyselAracTarihce
    {
        public DateTime DegistirilmeTarihi { get; set; }


        public int AracID { get; set; }
        public Arac Arac { get; set; }
        public int BireyselAracStatuID { get; set; }
        public BireyselAracStatu BireyselAracStatu { get; set; }
       
    }
}