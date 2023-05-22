using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkınciElAracSatis.CORE.Entities
{
    public class Rol
    {
        public int RolID { get; set; }
        public string KullaniciRol { get; set; }

        public List<Kullanici> Kullanicilar { get; set; }
        public List<AracIhale> AracIhaleleri { get; set; }
    }
}
