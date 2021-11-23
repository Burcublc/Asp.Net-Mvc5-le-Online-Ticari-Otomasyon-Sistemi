using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            //toplam cari sayısı
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            //toplam ürün sayısı
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            //personel sayısı
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            //kategori sayısı
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            //toplam stok
            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            //marka sayısı
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            //kritik seviye
            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            //max. fiyatlı ürün
            var deger8 = (from x in c.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            //min. fiyatlı Ürün
            var deger9 = (from x in c.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            //max.marka
            var deger10 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = deger10;

            //buzdolabı stok sayısı
            var deger11 = c.Uruns.Where(x => x.UrunAd == "Buzdolabı").Sum(x => x.Stok).ToString();
            ViewBag.d11 = deger11;

            //laptop sayısı
            var deger12 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d12 = deger12;

            //en çok satan ürün
            var deger13 = c.Uruns.Where(u=>u.UrunId==(c.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z=>z.Sum(k=>k.Adet)).Select(y => y.Key).FirstOrDefault())).Select(t=>t.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            //kasadaki tutar
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            //bugünkü satış miktarı
            DateTime bugun1 = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == bugun1).ToString();
            ViewBag.d15 = deger15;

            //bugünkü kasa
            //DateTime bugun=DateTime.Today; 'de yazabilirdik.
            DateTime bugun2 =DateTime.Parse( DateTime.Now.ToShortDateString());
            var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun2).Sum(y =>(decimal?)y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }

        public ActionResult KolayTablolar()
        {                     
            return View();
        }
        public PartialViewResult Partial1()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new GrupSinif
                        {
                            Sehir = g.Key, //Grubun içerisine dahil olacak alan
                            Sayi = g.Count() //grubumuzun ilgili sayıcağı ifadesi
                        };
            return PartialView(sorgu.ToList());
        }
        public PartialViewResult Partial()
        {
            var sorgu = from x in c.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new GrupSinif2
                        {
                            Departman = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.Where(x=>x.Durum==true).ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                        group x by x.Marka into g
                        select new GrupSinif3
                        {
                            Marka = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }
    }
}