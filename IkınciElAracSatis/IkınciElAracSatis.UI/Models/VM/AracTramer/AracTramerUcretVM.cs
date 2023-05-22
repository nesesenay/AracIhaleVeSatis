using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracTramer
{
    public class AracTramerUcretVM
    {
        public int AracID { get; set; }
        public decimal Ucret { get; set; }
        public int ParaBirimiID { get; set; } = 1;
        public int AracUcretTipID { get; set; } = 3;
    }
}