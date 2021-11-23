using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        //kısıtlamalar
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string PersonelBilgi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string PersonelAdres { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string PersonelMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string PersonelTel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string PersonelBrans { get; set; }

        //Bir personel birden fazla SatısHaereketinde olabilir o yüzden Icollection kullandık
        public ICollection<SatisHareket> SatisHarekets { get; set; }

        //bir personel bir departmanda bulunabilir o yüzden Departman sınıfından bir nesne türettik.

        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}