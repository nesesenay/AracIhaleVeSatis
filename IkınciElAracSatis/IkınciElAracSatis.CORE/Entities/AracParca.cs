using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracParca
    {
        [Key]
        public int AracParcaID { get; set; }
        [Required]
        [StringLength(50)]
        public string AracParcaAdi { get; set; }

        public List<AracDurum> AracDurumlari { get; set; }
    }
}