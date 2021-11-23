using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Siniflar;
using QRCoder;

namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            //arama motoru için
            var kargolar = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            }
            
            return View(kargolar.ToList());
           
        }
      
        [HttpGet]
        public ActionResult KargoEkle() 
        {
            Random rnd = new Random();
            string[] karakter = { "A", "B", "C", "D","E","F","G","H","I","J","K","L","M","N","O","P","R","S","T","U","V","Y","Z","X","W","Q" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakter.Length);//karakter dizisinde 4 eleman  var o yüzden
            k2 = rnd.Next(0, karakter.Length);//k2 = rnd.Next(0, 4);//karakter dizisinde 4 eleman  var o yüzden
            k3 = rnd.Next(0, karakter.Length);//karakter dizisinde 4 eleman  var o yüzden
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//100 ile 1000 arasında 3 basamaklı bir sayı türeticek.
            s2 = rnd.Next(10, 99);//10 ile 99 arasında 2 basamaklı bir sayi türeticek.
            s3 = rnd.Next(10, 99);//10 ile 99 arasında iki basamaklı bir sayi türeticek.
            string kod = s1.ToString() + karakter[k1] + s2.ToString() + karakter[k2] + s3.ToString() + karakter[k3];
            ViewBag.takipkod = kod;
            //QR Kod Ekleme İşlemi
            //Öncelikle refences kısmına yeni bir refences ekliyoruz QRCoder adında bu dll dosyasını udemyden indirdim ve projeye entegre ettim
            using (MemoryStream ms = new MemoryStream())//dosya akışında kullanılan bir sınıftır
            {
                QRCodeGenerator koduret = new QRCodeGenerator();//kod üretmek için bu sınıfı kullanıyoruz
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay k) 
        {          
            c.KargoDetays.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoDetay(string id) 
        {
            var sorgu = c.KargoTakips.Where(x => x.KargoTakipKodu == id).ToList();
            return View(sorgu);
        }
    }
}