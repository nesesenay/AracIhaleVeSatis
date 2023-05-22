using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracUcretTip
    {
        public int AracUcretTipID { get; set; }
        [Required]
        [StringLength(30)]
        public string UcretTipi { get; set; }

        public List<AracUcret> AracUcretleri { get; set; }
    }
}