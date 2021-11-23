using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;

namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();            
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CarilerEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CarilerEkle(Cariler m)
        {
            if (!ModelState.IsValid)
            {
                return View("CarilerEkle");
            }
            m.Durum = true;
            c.Carilers.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CarilerSil(int id)
        {
            var sorgu = c.Carilers.Find(id);
            sorgu.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CarilerGetir(int id)
        {
            var degerler = c.Carilers.Find(id);            
            return View("CarilerGetir",degerler);
        }
        public ActionResult CarilerGuncelle(Cariler m)
        {
            if (!ModelState.IsValid)
            {
                return View("CarilerGetir");
            }
            var sorgu = c.Carilers.Find(m.CariId);
            sorgu.CariAd = m.CariAd;
            sorgu.CariSoyad = m.CariSoyad;
            sorgu.CariMail = m.CariMail;
            sorgu.CariSehir = m.CariSehir;
            sorgu.Durum = m.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CarilerDetay(int id)
        {
            var musteriad = c.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.mstrad = musteriad;
            ViewBag.mstrid = id;
            var sorgu = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(sorgu);
        }
        public ActionResult AlisHareketleriYazdir(int id)
        {
            var sorgu = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(sorgu);
        }
    }
}