using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var sorgu = c.SatisHarekets.ToList();
            return View(sorgu);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urun = (from x in c.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunId.ToString()
                                         }).ToList();
            ViewBag.urn = urun;

            List<SelectListItem> cari = (from x in c.Carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariId.ToString()
                                         }).ToList();
            ViewBag.cr = cari;

            List<SelectListItem> persnl = (from x in c.Personels.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PersonelAd + " " + x.PersonelSoyad,
                                             Value = x.PersonelId.ToString()
                                         }).ToList();
            ViewBag.prsl = persnl;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urun = (from x in c.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunId.ToString()
                                         }).ToList();
            ViewBag.urn = urun;

            List<SelectListItem> cari = (from x in c.Carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariId.ToString()
                                         }).ToList();
            ViewBag.cr = cari;

            List<SelectListItem> persnl = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.prsl = persnl;
            var sorgu = c.SatisHarekets.Find(id);
            return View("SatisGetir",sorgu);
        }
        public ActionResult SatisGuncelle(SatisHareket sts)
        {
            sts.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            var sorgu = c.SatisHarekets.Find(sts.SatisId);
            sorgu.Adet = sts.Adet;
            sorgu.Fiyat = sts.Fiyat;
            sorgu.ToplamTutar = sts.ToplamTutar;
            sorgu.CariId = sts.CariId;
            sorgu.PersonelId = sts.PersonelId;
            sorgu.UrunId = sts.UrunId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var sorgu = c.SatisHarekets.Find(id);
            return View(sorgu);
        }
    }
}