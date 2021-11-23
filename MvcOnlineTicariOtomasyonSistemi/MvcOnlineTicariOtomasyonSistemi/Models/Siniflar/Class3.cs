using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Class3
    {
        public IEnumerable<Faturalar> deger1 { get; set; }//Model klasöründeki sınıflar klasöründen Faturalar sınıfından bir değişken oluşturuyoruz
        public IEnumerable<FaturaKalem> deger2 { get; set; }//Model klasöründeki sınıflar klasöründen Faturakalem sınıfından bir değişken oluşturuyoruz
    }
}