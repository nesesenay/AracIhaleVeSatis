using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class Versiyon
    {
        [Key]
        public int VersiyonID { get; set; }
        [Required]
        [StringLength(30)]
        public string AracVersiyon { get; set; }

        public List<AracDetay> AracDetaylari { get; set; }
    }
}