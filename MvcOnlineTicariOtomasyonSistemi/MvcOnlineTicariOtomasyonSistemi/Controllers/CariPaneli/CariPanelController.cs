using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers.CariPaneli
{
    
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            //var cari=c.Carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariId).FirstOrDefault(); olarakta cariid'i getirebilirdik.
            var cariid = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            var toplamAlisSayisi = c.SatisHarekets.Where(x => x.CariId == cariid.CariId).Sum(y=>y.Adet).ToString();
            ViewBag.d1 = toplamAlisSayisi;

            
            var toplamKargoÜrünSayısı = c.KargoDetays.Where(x => x.Alici == cariid.CariAd+" "+cariid.CariSoyad).Count().ToString();
            ViewBag.d2 = toplamKargoÜrünSayısı;

            var toplamharcanan = c.SatisHarekets.Where(x => x.CariId == cariid.CariId).Sum(y => y.ToplamTutar).ToString();
            ViewBag.d3=toplamharcanan;
            //var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            var degerler = c.Carilers.Where(x => x.CariMail == mail).ToList();
            ViewBag.m = mail;
            return View(degerler);
        }
        public PartialViewResult CariBilgisiGetir() 
        {           
            var mail = (string)Session["CariMail"];
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            var sorgu = c.Carilers.Find(bilgiler.CariId);
            return PartialView("CariBilgisiGetir", sorgu);
        }
        public ActionResult CariBilgisiGuncelle(Cariler cr) 
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);//dosyanın adını al
                string uzanti = Path.GetExtension(Request.Files[0].FileName);//dosyanın uzantısını al
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                cr.Gorsel = "/Image/" + dosyaadi + uzanti;
            }
            var sorgu = c.Carilers.Find(cr.CariId);
            sorgu.CariAd = cr.CariAd;
            sorgu.CariSoyad = cr.CariSoyad;
            sorgu.Gorsel = cr.Gorsel;
            sorgu.CariMail = cr.CariMail;
            sorgu.CariSifre = cr.CariSifre;
            sorgu.CariSehir = cr.CariSehir;
            sorgu.Meslek = cr.Meslek;
            sorgu.Telefon = cr.Telefon;
            sorgu.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index","CariPanel");
            
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar() 
        {
            var mail = (string)Session["CariMail"];
            var sorgu = c.Mesajlars.Where(x=>x.Alici == mail).OrderByDescending(x=>x.MesajId).ToList();

            var gelenmesajsayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;
            var gonderilenmesajsayisi = c.Mesajlars.Count(x => x.Kimden == mail).ToString();
            ViewBag.d2 = gonderilenmesajsayisi;
            return View(sorgu);
        }
        public ActionResult GonderilenMesajlar() 
        {
            var mail = (string)Session["CariMail"];
            var sorgu = c.Mesajlars.Where(x => x.Kimden == mail).OrderByDescending(x=>x.MesajId).ToList();

            var gelenmesajsayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;
            var gonderilenmesajsayisi = c.Mesajlars.Count(x => x.Kimden == mail).ToString();
            ViewBag.d2 = gonderilenmesajsayisi;
            return View(sorgu);
        }
        public ActionResult MesajDetay(int id) 
        {
            var mail = (string)Session["CariMail"];

            var sorgu = c.Mesajlars.Where(x=>x.MesajId==id).ToList();

            var gelenmesajsayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;
            var gonderilenmesajsayisi = c.Mesajlars.Count(x => x.Kimden == mail).ToString();
            ViewBag.d2 = gonderilenmesajsayisi;
            return View(sorgu);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenmesajsayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;
            var gonderilenmesajsayisi = c.Mesajlars.Count(x => x.Kimden == mail).ToString();
            ViewBag.d2 = gonderilenmesajsayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Kimden = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return RedirectToAction("GonderilenMesajlar");
        }
        public ActionResult KargoTakip(string p) 
        {
            //Arama Motoru için
            var kargolar = from x in c.KargoDetays select x;
            kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));


            return View(kargolar.ToList());
        }

        public ActionResult KargoDetay(string id) 
        {
            var sorgu = c.KargoTakips.Where(x => x.KargoTakipKodu == id).ToList();
            return View(sorgu);
        }

        public ActionResult Cikis() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

        public PartialViewResult MesajListele() 
        {
            var mail = (string)Session["CariMail"];
           
            var sorgu = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            
            return PartialView(sorgu);
        }

        public PartialViewResult Duyurular() 
        {
            var sorgu = c.Mesajlars.Where(x => x.Kimden == "a").ToList();
            return PartialView(sorgu);
        }
    }
}