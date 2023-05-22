using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class Renk
    {
        [Key]
        public int RenkID { get; set; }
        [Required]
        [StringLength(30)]
        public string AracRenk { get; set; }

        public List<AracDetay> AracDetaylari { get; set; }
    }
}