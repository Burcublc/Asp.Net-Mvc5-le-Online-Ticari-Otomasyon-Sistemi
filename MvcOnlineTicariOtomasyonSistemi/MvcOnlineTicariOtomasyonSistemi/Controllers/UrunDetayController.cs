using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index(int id)
        {
            Class1 cs = new Class1(); //Oluşturduğumuz sınıf türünde bir nesne oluşturduk bu nesne sayesinde veritabanımdaki verileri sınıfta oluşturduğum verilere aktarabilecek ve veriler sayesinde index sayfasında kullabileceğim
            //var sorgu = c.Uruns.Where(x=>x.UrunId==1).ToList();
            cs.Deger1 = c.Uruns.Where(x => x.UrunId == id).ToList();
            cs.Deger2 = c.Detays.Where(x => x.DetayId == id).ToList();
            return View(cs);
        }
    }
}