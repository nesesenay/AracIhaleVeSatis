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
    public class Komisyon
    {
        [Key,ForeignKey("Arac")]
        public int AracID { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }


        public int BelirlenenKomisyonID { get; set; }
        public BelirlenenKomisyon BelirlenenKomisyon { get; set; }
        public Arac Arac { get; set; }

    }
}
