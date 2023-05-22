using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class YakitTip
    {
        [Key]
        public int YakitTipID { get; set; }
        [Required]
        [StringLength(15)]
        public string AracYakitTipi { get; set; }

        public List<AracDetay> AracDetaylari { get; set; }
    }
}