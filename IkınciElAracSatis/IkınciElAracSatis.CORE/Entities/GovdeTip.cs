using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class GovdeTip
    {
        [Key]
        public int GovdeTipID { get; set; }
        [Required]
        [StringLength(20)]
        public string AracGovdeTipi { get; set; }

        public List<AracDetay> AracDetaylari { get; set; }
    }
}