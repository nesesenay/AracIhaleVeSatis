using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracTramer
{
    public class AracTramerVM
    {
        public List<AracParcaVM> AracParcalari { get; set; }
        public List<AracParcaDurumuVM> AracParcaDurumlari { get; set; }
        public AracTramerUcretVM AracTramerUcreti { get; set; }
    }
}