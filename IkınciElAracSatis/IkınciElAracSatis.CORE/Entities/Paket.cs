using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class Paket
    {
        [Key]
        public int PaketID { get; set; }
        [Required]
        [StringLength(10)]
        public string PaketAdi { get; set; }

        public List<PaketTanimlama> PaketTanimlamalari { get; set; }
    }
}