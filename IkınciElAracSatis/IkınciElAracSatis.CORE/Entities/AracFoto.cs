﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracFoto
    {
        [Key]
        public int AracFotoID { get; set; }
        public string AracFoto1 { get; set; }
        public string AracFoto2 { get; set; }
        public string AracFoto3 { get; set; }
        public string AracFoto4 { get; set; }
        public string AracFoto5 { get; set; }

        public List<AracDetay> AracDetaylari { get; set; }
    }
}