using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.Kullanici
{
    public class KurumsalKullaniciVM
    {
        public int KurumsalKullaniciID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string CepTelefonu { get; set; }
        public string İl { get; set; }
        public string İlce { get; set; }
        public string Adres { get; set; }
        public bool OnayliMi { get; set; }
        public int AracStokMiktari { get; set; }
        public string SirketBilgisi { get; set; }
        public string SirketAdi { get; set; }
    }
}