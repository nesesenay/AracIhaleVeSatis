using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.AracIhale
{
    public class DBAracIhaleVM
    {
        public string IhaleAdi { get; set; }
        public DateTime IhaleBaslangicTarihi { get; set; }
        public DateTime IhaleBitisTarihi { get; set; }
        public string IhaleBaslangicSaati { get; set; }
        public string IhaleBitisSaati { get; set; }
        public DateTime KaydetmeTarihi { get; set; }
        public int RolID { get; set; }
        public int SirketID { get; set; }
        public int IhaleStatuID { get; set; }


        public List<SelectListItem> Roller { get; set; }
        public List<SelectListItem> Sirketler { get; set; }
        public List<SelectListItem> IhaleStatuleri { get; set; }
    }
}