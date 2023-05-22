using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracDurum
    {
        [Key]
        public int AracDurumID { get; set; }
        public int AracID { get; set; }
        public Arac Arac { get; set; }
        public int AracParcaID { get; set; }
        public AracParca AracParcalari { get; set; }
        public int AracParcaDurumID { get; set; }
        public AracParcaDurum AracParcaDurum { get; set; }
    }
}