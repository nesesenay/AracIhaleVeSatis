using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class Model
    {
        [Key]
        public int ModelID { get; set; }
        [Required]
        [StringLength(50)]
        public string ModelAdi { get; set; }
        public int MarkaID { get; set; }
        public Marka Marka { get; set; }

        public List<Arac> Araclar { get; set; }
    }
}