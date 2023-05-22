using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class Plaka
    {
        [Key]
        public int PlakaID { get; set; }
        [Required]
        [StringLength(50)]
        public string AracPlaka { get; set; }

        public List<Arac> Arac { get; set; }
    }
}