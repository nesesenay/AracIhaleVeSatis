using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkınciElAracSatis.CORE.Entities
{
    public class AracStatuLog
    {

        [ForeignKey("Arac")]
        public int AracID { get; set; }
        [ForeignKey("AracStatu")]
        public int AracStatuID { get; set; }
        public DateTime KaydedilenTarih { get; set; }

        public AracStatu AracStatu { get; set; }
        public Arac Arac { get; set; }
    }
}
