using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        //ürün sınıfıyla ilişkilidir
        //cariler sınıfıyla ilişkilidir.
        //personel sınıfıyla ilişkilidir.
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int UrunId { get; set; }
        //bir satış Hareketinde  bir ürün olabilir. O yüzden sınıf türettik Kullanacağız
        public virtual Urun Urun { get; set; }

        public int CariId { get; set; }
        //bir satış Hareketinde bir cari olabilir. O yüzden Sınıftan türettik
        public virtual Cariler Cariler { get; set; }

        public int PersonelId { get; set; }
        //bir satış Hareketinde bir personel olabilir. O yüzden Sınıftan Türettik
        public virtual Personel Personel { get; set; }
    }
}