using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class IhaleFiyatBelirleme
    {
        [Key, ForeignKey("Arac")]
        public int AracID { get; set; }
        public decimal IhaleBaslangicFiyati { get; set; }
        public decimal MinimumAlimFiyati { get; set; }

        public int ParaBirimID { get; set; }
        public ParaBirim ParaBirim { get; set; }
        public Arac Arac { get; set; }
    }
}