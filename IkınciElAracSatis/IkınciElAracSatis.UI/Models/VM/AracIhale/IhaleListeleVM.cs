using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.AracIhale
{
    public class IhaleListeleVM
    {
        public int AracIhaleID { get; set; }
        public string IhaleAdi { get; set; }
        public DateTime IhaleBaslangicTarihi { get; set; }
        public DateTime IhaleBitisTarihi { get; set; }
        public string IhaleBaslangicSaati { get; set; }
        public string IhaleBitisSaati { get; set; }
        public DateTime KaydetmeTarihi { get; set; }
        public string Rol { get; set; }
        public string Sirket { get; set; }
        public string Kullanici { get; set; }
        public string IhaleStatu { get; set; }
    }
}