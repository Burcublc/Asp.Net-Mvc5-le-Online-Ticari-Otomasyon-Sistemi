using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context c = new Context();//context sınıfından bir nesne türettim
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,4);//kategori tablosundaki sütunlara git bunu değerler değişkenine ata

            return View(degerler);//sonra geri degerler değişkenini döndürür 
        }
        //form yüklendiği zaman burayı(alttakini)çalıştır
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View(); //KategoriEkle.cshtml sayfasını çalıştırır
        }
        //butona tıklandığında ekleme yapmak için burayı çalıştırır
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k); //veritabanına ekliyor
            c.SaveChanges(); //değişlikleri kaydediyor
            return RedirectToAction("Index"); //Index Fonsiyonuna gider
        }

        public ActionResult KategoriSil(int id)
        {
            var sorgu = c.Kategoris.Find(id);
            c.Kategoris.Remove(sorgu);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var sorgu = c.Kategoris.Find(id);            
            return View("KategoriGetir",sorgu);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var sorgu = c.Kategoris.Find(k.KategoriId);
            sorgu.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        //Cascading işlemi için aşağıdaki actionı oluşturduk.
        public ActionResult Deneme() 
        {
            Class2 cs = new Class2();
            cs.Kategoriler = new SelectList(c.Kategoris, "KategoriId", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "UrunId", "UrunAd");
            return View(cs);
        }
        public JsonResult UrunGetir(int p) 
        {
            var UrunListesi = (from x in c.Uruns
                               join y in c.Kategoris
                               on x.Kategori.KategoriId equals y.KategoriId
                               where x.Kategori.KategoriId == p
                               select new
                               {
                                   Text = x.UrunAd,
                                   Value = x.UrunId.ToString()
                               }).ToList();
            return Json(UrunListesi, JsonRequestBehavior.AllowGet);                   

        }

    }
}