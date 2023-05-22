using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.Models
{
    public class KullaniciVM
    {
        public int KullaniciID { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public int RolID { get; set; }
    }
}