using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }

        //kısıtlamalar
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }

        //bir departmanda birden fazla personel olabilir o yüzden burda bir ICollection oluşturacağız.
        public ICollection<Personel> Personels { get; set; }

        public bool Durum { get; set; }
    }
}