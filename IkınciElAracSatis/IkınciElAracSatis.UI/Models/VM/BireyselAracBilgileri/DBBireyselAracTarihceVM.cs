using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri
{
    public class DBBireyselAracTarihceVM
    {
        public DateTime DegistirilmeTarihi { get; set; } = DateTime.Now;
        public int AracID { get; set; }
        public int BireyselAracStatuID { get; set; }

    }
}