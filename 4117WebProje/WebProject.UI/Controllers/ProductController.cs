using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Model.Entities;
using WebProject.Service.Option;

namespace WebProject.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }

        public ActionResult GetProducts(Guid id)
        {
            List<Product> urunler = _productService.GetDefault(x => x.SubCategoryID == id && x.Durumu==Core.Entity.Enum.Status.Active).ToList();

            return View(urunler);
        }
    }
}