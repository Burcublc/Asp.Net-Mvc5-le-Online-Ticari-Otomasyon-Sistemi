using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }

        //kısıtlamalar
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }

        public DateTime FaturaTarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string FaturaSaati { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }

        //bir faturanın birden fazla faturakalemi olabilir,bir faturakaleminin bir faturası olur.bu yüzden burası IColletion olur
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}