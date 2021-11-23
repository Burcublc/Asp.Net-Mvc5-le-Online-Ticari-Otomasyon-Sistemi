using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Class1
    {
        public IEnumerable<Urun> Deger1 { get; set; }//Model klasöründeki sınıflar klasöründen Urun sınıfından bir değişken oluşturuyoruz
        public IEnumerable<Detay> Deger2 { get; set; }//Model klasöründeki sınıflar klasöründen Detay sınıfından bir değişken oluşturuyoruz
    }
}