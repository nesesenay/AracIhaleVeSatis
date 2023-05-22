using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracIhale
{
    public class AracIhaleVM
    {
        public string IhaleAdi { get; set; }
        public DateTime IhaleBaslangicTarihi { get; set; }
        public DateTime IhaleBitisTarihi { get; set; }
        public string IhaleBaslangicSaati { get; set; }
        public string IhaleBitisSaati { get; set; }
        public DateTime KaydetmeTarihi { get; set; } = DateTime.Now;
        public int RolID { get; set; }
        public int SirketID { get; set; }
        public int KullaniciID { get; set; }
        public int IhaleStatuID { get; set; }
    }
}