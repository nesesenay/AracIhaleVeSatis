using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class IhaleyeAracEkleme
    {

        public int AracID { get; set; }
        public int AracIhaleID { get; set; }

        [ForeignKey("AracID")]
        public Arac Arac { get; set; }

        [ForeignKey("AracIhaleID")]
        public AracIhale AracIhale { get; set; }


    }
}