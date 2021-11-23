using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;

namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2() 
        {
            var grafikciz = new Chart(width:600,height:600);
            grafikciz.AddTitle("Kategori ve Ürün Sayıları").AddLegend("Stok").AddSeries("Değerler",xValue:new[] { "Beyaz Eşya", "Telefon", "Küçük Ev Aletleri", "Bilgisayar", "Mobilya", "Televizyon", "Klima Ve Isıtıcılar" },yValues:new[] { 500, 250, 340, 620, 132, 450, 785 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3() 
        {
            //veritabanından çekme
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));//xvalue listesinin içerisine urunadını ekle
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));

            var grafikciz = new Chart(width: 600, height: 600);
            grafikciz.AddTitle("Ürün Ve Stok Sayıları").AddLegend("Stok").AddSeries(chartType:"Pie",name:"Değerler", xValue:xvalue, yValues:yvalue).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4() 
        {
            return View();
        }     
        public ActionResult VisualizeUrunResult() 
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1> UrunListesi() 
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
            {
                UrunAd = "Bilgisayar",
                Stok = 120
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Beyaz Eşya",
                Stok = 100
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Mobilya",
                Stok = 70
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Küçük Ev Aletleri",
                Stok = 40
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Mobil Cihazlar",
                Stok = 90
            });
            return snf;
        }
        public ActionResult Index5() 
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2() 
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif2> UrunListesi2() 
        {
            List<Sinif2> snf = new List<Sinif2>();
            using (var context = new Context()) 
            {
                snf=c.Uruns.Select(x=>new Sinif2 
                {
                    urn=x.UrunAd,
                    stk=x.Stok
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6() 
        {
            return View();
        }
        public ActionResult Index7() 
        {
            return View();
        }
     
      
    }

}