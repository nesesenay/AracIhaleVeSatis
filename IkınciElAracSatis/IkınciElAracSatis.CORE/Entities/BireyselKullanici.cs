using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class BireyselKullanici
    {
        [Key, ForeignKey("Kullanici")]
        public int KullaniciID { get; set; }
        public bool KvkkIsaretliMi { get; set; }


      
        public Kullanici Kullanici { get; set; }
    }
}