using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.Models.VM.AracTramer
{
    public class AracParcaDurumuVM
    {
        public int AracParcaDurumID { get; set; }
        public string ParcaDurumu { get; set; }

    }
}