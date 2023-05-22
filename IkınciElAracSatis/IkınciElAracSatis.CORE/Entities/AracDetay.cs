using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace IkinciElAracSatis.CORE.Entities
{
    public class AracDetay
    {
        [Key, ForeignKey("Arac")]
        public int AracID { get; set; }
        [Required]
        [StringLength(20)]
        public string MotorGucu { get; set; }
        [Required]
        [StringLength(20)]
        public string MotorHacmi { get; set; }
        [Required]
        [StringLength(4)]
        public string Yıl { get; set; }
        [Required]
        public decimal KmBilgisi { get; set; }
        public string Aciklama { get; set; }

       
        public int AracFotoID { get; set; }
        public AracFoto AracFoto { get; set; }
        public int OpsiyonelDonanimID { get; set; }
        public OpsiyonelDonanim OpsiyonelDonanim { get; set; }
        public int VersiyonID { get; set; }
        public Versiyon Versiyon { get; set; }
        public int RenkID { get; set; }
        public Renk Renk { get; set; }
        public int VitesTipID { get; set; }
        public VitesTip VitesTip { get; set; }
        public int YakitTipID { get; set; }
        public YakitTip YakitTip { get; set; }
        public int GovdeTipID { get; set; }
        public GovdeTip GovdeTip { get; set; }


        public Arac Arac { get; set; }

    }
}