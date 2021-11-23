using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Kategori
    {

        
        [Key]
        public int KategoriId { get; set; }

        [Display(Name ="Kategori Adı:")]
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string KategoriAd { get; set; }

        //Ürüne ve Kategori arasında 1' e çok ilişki vardır.Yani bir kategoride 1'den fazla ürün olabilir ama bir ürün 1 kategoriye aittir.
        //ICollection<sınıfadı>... ilişkili sınıflarımızı tutan bir değişken türüdür
        public ICollection<Urun> Uruns { get; set; }//Her bir kategoride birden fazla ürün yer alabilir

    }
}