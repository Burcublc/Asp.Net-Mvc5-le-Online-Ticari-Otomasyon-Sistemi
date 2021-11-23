using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        //Urunad ve marka için kısıtlama getirdik çünkü string veri tipi ram de çok yer kapladığından böyle bir şey yaptık.

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        //Ürünlerimizin Sadece bir tane kategori olabilir.
        //Aşağıdakini yazarak Kategori sınıfından bir tane değer almasını sağlıyoruz o ürünün
        // public [sınıfadi] değişken adı {....
        public int KategoriId { get; set; }//properties ouşturduk kategoriid için
        public virtual Kategori Kategori { get; set; }//kategori sınıfındaki değerlere ulaşabilmemeiz için kod sırasında virtual yazdık.

        //Bir Urun birden fazla SatısHareketinde olabilir o yüzden ICollection ' kullandık
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}