using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.BireyselAracBilgileri
{
    public class BireyselAracGetirVM
    {
        public int AracID { get; set; }
        public int AracNo { get; set; }
        public string ModelAdi { get; set; }
        public int ModelID { get; set; }
        public string MarkaAdi { get; set; }
        public int MarkaID { get; set; }
        public string AdminAdi { get; set; }
        public int AdminID { get; set; }
        public DateTime KaydedilenTarih { get; set; }
        public string BireyselStatu { get; set; }
        public int BireyselStatuID { get; set; }


        public List<SelectListItem> AracNolari { get; set; }
        public List<SelectListItem> Modeller { get; set; }
        public List<SelectListItem> Markalar { get; set; }
        public List<SelectListItem> Adminler { get; set; }
        public List<SelectListItem> BireyselStatuler { get; set; }
    }
}