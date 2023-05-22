using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models.VM.Kullanici
{
    public class BireyselKullaniciVM
    {
        public int BireyselKullaniciID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string CepTelefonu { get; set; }
    }
}