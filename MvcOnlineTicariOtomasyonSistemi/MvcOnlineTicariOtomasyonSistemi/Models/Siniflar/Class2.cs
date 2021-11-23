using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Class2
    {
        public IEnumerable<SelectListItem> Kategoriler { get; set; }//SelectListItem tipinde bir IEnumerable değişkeni oluşturuyoruz adı Kategoriler
        public IEnumerable<SelectListItem> Urunler { get; set; }//SelectListItem tipinde bir IEnumerable değişkeni oluşturuyoruz adı Urunler
    }
}