using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class OpsiyonelDonanim
    {
        [Key]
        public int OpsiyonelDonanimID { get; set; }
        [Required]
        [StringLength(50)]
        public string AracOpsiyonelDonanim { get; set; }

        public List<AracDetay> AracDetaylari { get; set; }
    }
}