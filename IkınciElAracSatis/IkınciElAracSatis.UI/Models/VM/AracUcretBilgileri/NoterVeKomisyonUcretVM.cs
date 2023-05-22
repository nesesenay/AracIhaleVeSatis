using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri
{
    public class NoterVeKomisyonUcretVM
    {
        public KomisyonUcretVM KomisyonUcreti { get; set; }
        public NoterUcretVM NoterUcreti { get; set; }
    }
}