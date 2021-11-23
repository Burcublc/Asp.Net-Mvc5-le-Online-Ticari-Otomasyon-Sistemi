using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var sorgu = c.Faturalars.ToList();
            return View(sorgu);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var sorgu = c.Faturalars.Find(id);
            return View("FaturaGetir",sorgu);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var sorgu = c.Faturalars.Find(f.FaturaId);
            sorgu.FaturaSeriNo = f.FaturaSeriNo;
            sorgu.FaturaSiraNo = f.FaturaSiraNo;
            sorgu.FaturaTarih = f.FaturaTarih;
            sorgu.VergiDairesi = f.VergiDairesi;
            sorgu.FaturaSaati = f.FaturaSaati;
            sorgu.TeslimEden = f.TeslimEden;
            sorgu.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var detayfatura = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            //var ftrid = c.FaturaKalems.Where(x => x.FaturaId == id).Select(y => y.FaturaId).FirstOrDefault();
            //ViewBag.fid = ftrid;
            return View(detayfatura);
        }
        [HttpGet]
        public ActionResult FaturaKalemEkle(/*int id*/)
        {
            //var ftrid = c.FaturaKalems.Where(x => x.FaturaId == id).Select(y => y.FaturaId).FirstOrDefault();
            //ViewBag.fid = ftrid;                  
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem k)
        {         
            c.FaturaKalems.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public PartialViewResult Partial1()
        {
            var detayfatura = c.FaturaKalems.Where(x => x.FaturaId == 1).ToList();
            return PartialView(detayfatura);
        }

        public ActionResult Dinamik() 
        {
            Class3 cs = new Class3();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo, DateTime FaturaTarih, string
            FaturaSaati, string TeslimEden, string TeslimAlan, string VergiDairesi, string Toplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.FaturaTarih = FaturaTarih;
            f.FaturaSaati = FaturaSaati;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.VergiDairesi = VergiDairesi;
            f.Toplam = decimal.Parse(Toplam);
            c.Faturalars.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.FaturaId = x.FaturaKalemId;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
      
    }
}