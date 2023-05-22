using IkınciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracIhale
    {
        [Key]
        public int AracIhaleID { get; set; }
        [Required]
        [StringLength(50)]
        public string IhaleAdi { get; set; }
        [Required]
        public DateTime IhaleBaslangicTarihi { get; set; }
        [Required]
        public DateTime IhaleBitisTarihi { get; set; }
        [Required]
        [StringLength(5)]
        public string IhaleBaslangicSaati { get; set; }
        [Required]
        [StringLength(5)]
        public string IhaleBitisSaati { get; set; }
        [Required]
        public DateTime KaydetmeTarihi { get; set; }

        public int KullaniciID { get; set; }
        [ForeignKey("Kullanici")]
        public Kullanici Kullanici { get; set; }
        public int RolID { get; set; }
        [ForeignKey("RolID")]
        public Rol Rol { get; set; }
        public int SirketID { get; set; }
        [ForeignKey("SirketID")]
        public Sirket Sirket { get; set; }
        public int IhaleStatuID { get; set; }
        public IhaleStatu IhaleStatu { get; set; }
        public List<IhaleyeAracEkleme> IhaleyeAracEklemeler { get; set; }
        public List<AracIhaleSahip> AracIhaleSahipleri { get; set; }
    }
}