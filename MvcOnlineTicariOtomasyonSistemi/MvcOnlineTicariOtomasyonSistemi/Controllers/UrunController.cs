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
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var degerler = from x in c.Uruns select x;
            //arama butonu için
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(y => y.UrunAd.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd, //DİSPLAY MEMBER
                                               Value = x.KategoriId.ToString()  //VALUE MEMBER
                                           }).ToList();
            //ViewBag controller tarafından view'e değer taşımak için kullanılır. iskeleti;ViewBag.değişkenismi=gelen değer
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var sorgu = c.Uruns.Find(id);
            sorgu.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    
        public ActionResult UrunGetir(int id)
        {
           
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                        select new SelectListItem
                                        {
                                           Text = x.KategoriAd,
                                           Value = x.KategoriId.ToString()
                                        }).ToList();
            ViewBag.dgr1 = deger1;

            var sorgu=c.Uruns.Find(id);
            return View("UrunGetir",sorgu);
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            var sorgu = c.Uruns.Find(u.UrunId);
            sorgu.UrunAd = u.UrunAd;
            sorgu.Marka = u.Marka;
            sorgu.Stok = u.Stok;
            sorgu.AlisFiyati = u.AlisFiyati;
            sorgu.SatisFiyati = u.SatisFiyati;
            sorgu.Durum = u.Durum;
            sorgu.UrunGorsel = u.UrunGorsel;
            sorgu.KategoriId = u.KategoriId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id) 
        {

            List<SelectListItem> deger1 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd+" "+x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd+" "+x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
           
            var deger3 = c.Uruns.Find(id);
            ViewBag.dgr3 = deger3.UrunId;
            ViewBag.dgr4 = deger3.SatisFiyati;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket s) 
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }
    }
}