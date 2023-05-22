using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class VitesTip
    {
        [Key]
        public int VitesTipID { get; set; }
        [Required]
        [StringLength(20)]
        public string AracVitesTipi { get; set; }

        public List<AracDetay> AracDetaylari { get; set; }
    }
}