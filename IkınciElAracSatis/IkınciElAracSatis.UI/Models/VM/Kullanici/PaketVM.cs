using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.Kullanici
{
    public class PaketVM
    {
        public int PaketID { get; set; }
        public string PaketAdi { get; set; }


        public List<SelectListItem> Paketler { get; set; }
    }
}