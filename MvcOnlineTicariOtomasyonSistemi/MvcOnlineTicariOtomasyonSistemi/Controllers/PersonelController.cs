using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> dprt = (from x in c.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanId.ToString()
                                         }).ToList();
            ViewBag.d = dprt;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0) 
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını al
                string uzanti = Path.GetExtension(Request.Files[0].FileName);//dosyanın uzantısını al
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> dprt = (from x in c.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanId.ToString()
                                         }).ToList();
            ViewBag.d = dprt;

            var sorgu = c.Personels.Find(id);

            return View("PersonelGetir",sorgu);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını al
                string uzanti = Path.GetExtension(Request.Files[0].FileName);//dosyanın uzantısını al
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            var sorgu = c.Personels.Find(p.PersonelId);
            sorgu.PersonelAd = p.PersonelAd;
            sorgu.PersonelSoyad = p.PersonelSoyad;
            sorgu.PersonelGorsel = p.PersonelGorsel;
            sorgu.DepartmanId = p.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}