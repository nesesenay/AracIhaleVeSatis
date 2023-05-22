using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracUcret
    {
        [Key, ForeignKey("Arac")]
        public int AracID { get; set; }
        public decimal Ucret { get; set; }

        [ForeignKey("ParaBirim")]
        public int ParaBirimiID { get; set; }
        public ParaBirim ParaBirim { get; set; }

        [ForeignKey("AracUcretTip")]
        public int AracUcretTipID { get; set; }
        public AracUcretTip AracUcretTip { get; set; }


        public Arac Arac { get; set; }
    }
}