using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            d.Durum = true;
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var sorgu=c.Departmans.Find(id);
            sorgu.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var sorgu = c.Departmans.Find(id);
            return View("DepartmanGetir", sorgu);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var sorgu = c.Departmans.Find(d.DepartmanId);
            sorgu.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {         
            var personellerigetir = c.Personels.Where(x=>x.DepartmanId == id).ToList();
            var departmanad = c.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dptad = departmanad;
            return View(personellerigetir);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var personelsatishareketleri = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var personelad = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.prslad = personelad;
            ViewBag.prslid = id;
            return View(personelsatishareketleri);
        }
        public ActionResult SatisListesiYazdir(int id)
        {
            var degerler = c.SatisHarekets.Where(x=>x.PersonelId==id).ToList();
            return View(degerler);
        }
    }
}