using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class Marka
    {
        [Key]
        public int MarkaID { get; set; }
        [Required]
        [StringLength(30)]
        public string MarkaAdi { get; set; }

        public List<Model> Models { get; set; }
    }
}