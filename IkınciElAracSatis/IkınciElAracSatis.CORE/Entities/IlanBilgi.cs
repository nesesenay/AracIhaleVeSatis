using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class IlanBilgi
    {
        [Key, ForeignKey("Arac")]
        public int AracID { get; set; }
        [Required]
        [StringLength(60)]
        public string IlanBasligi { get; set; }
        [Required]
        [StringLength(500)]
        public string Aciklama { get; set; }

        public Arac Arac { get; set; }
    }
}