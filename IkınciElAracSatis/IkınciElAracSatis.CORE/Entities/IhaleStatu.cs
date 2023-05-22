using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class IhaleStatu
    {
        [Key]
        public int IhaleStatuID { get; set; }
        [Required]
        [StringLength(30)]
        public string IhaleninSatusu { get; set; }

        public List<AracIhale> AracIhaleleri { get; set; }
    }
}