using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkınciElAracSatis.CORE.Entities
{
    public class BelirlenenKomisyon
    {
        public int BelirlenenKomisyonID { get; set; }
        public decimal KomisyonUcret { get; set; }
        public decimal AltLimit { get; set; }
        public decimal UstLimit { get; set; }


        public int ParaBirimID { get; set; }
        public ParaBirim ParaBirim { get; set; }
        public List<Komisyon> Komisyonlar { get; set; }
    }
}
