using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.dg1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.dg2 = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.dg3 = deger3;
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.dg4 = deger4;
            var sorgu = c.Yapilacaks.ToList();
            return View(sorgu);
        }
    }
}