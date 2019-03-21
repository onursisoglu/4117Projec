using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Model.Entities;
using WebProject.Service.Option;
using WebProject.UI.Models;

namespace WebProject.UI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<Sepet> sepetUrunleri = Session["sepetim"] as List<Sepet>;

            return View(sepetUrunleri);
        }


        ProductService _productService = new ProductService();

        public ActionResult AddToCart(Guid id)
        {
            List<Sepet> sepetListesi = new List<Sepet>();

            Product p = _productService.GetByID(id);

            if (Session["sepetim"] != null)
            {
                sepetListesi = Session["sepetim"] as List<Sepet>;
            }

            Sepet urun;
            if (sepetListesi.Any(x => x.ID == id)) // sepette parametre ile eşleşen id'de ürün var mı yok mu  ?
            {
                // var ise ürünü bul
                urun = sepetListesi.FirstOrDefault(x => x.ID == id);
                //adetini bir arttır.
                urun.Adet++;
            }
            // sepette parametre ile eşleşen id'de ürün yoksa eğer gel yeni ürün oluşturup sepete ekle
            else
            {
                urun = new Sepet();
                urun.ID = p.ID;
                urun.UrunAdi = p.Name;
                urun.Fiyati = p.Price;
                urun.Adet = 1;
                urun.ImagePath = p.ImagePath;

                sepetListesi.Add(urun);
            }

            Session["sepetim"] = sepetListesi;
            return Json(sepetListesi, JsonRequestBehavior.AllowGet);
        }

    }
}