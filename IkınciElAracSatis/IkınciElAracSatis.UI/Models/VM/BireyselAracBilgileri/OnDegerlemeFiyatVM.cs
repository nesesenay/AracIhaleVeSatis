using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri
{
    public class OnDegerlemeFiyatVM
    {
        public int AracID { get; set; }
        public decimal OnDegerlemeTutari { get; set; }
        public bool OnayliMi { get; set; } = false;
        public int KullaniciID { get; set; }
    }
}