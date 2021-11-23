using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }

        //kısıtlamalar
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        //bir faturakalemin sadece bir tane faturası olur. Oyüzden Faturalar sınıfından bir tane değişken nesne oluşturduk..
        public int FaturaId { get; set; }
        public virtual Faturalar Faturalar { get; set; }
    }
}