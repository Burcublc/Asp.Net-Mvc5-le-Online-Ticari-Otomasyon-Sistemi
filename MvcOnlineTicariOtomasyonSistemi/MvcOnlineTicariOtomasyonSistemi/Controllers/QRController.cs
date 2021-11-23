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
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kod) 
        {
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
    }
}