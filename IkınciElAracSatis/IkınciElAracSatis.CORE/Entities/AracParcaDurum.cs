using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracParcaDurum
    {
        [Key]
        public int AracParcaDurumID { get; set; }
        [Required]
        [StringLength(50)]
        public string ParcaDurumu { get; set; }

        public List<AracDurum> AracDurumlari { get; set; }
    }
}