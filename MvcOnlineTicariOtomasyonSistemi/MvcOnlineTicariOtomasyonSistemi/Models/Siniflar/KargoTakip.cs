using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KargoTakipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}