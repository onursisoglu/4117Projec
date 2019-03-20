using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Model.Entities;
using WebProject.Service.Option;
using WebProject.UI.Areas.Admin.Models.ViewModels;
using WebProject.UI.Utility;

namespace WebProject.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product

        ProductService _productService;
        SubCategoryService _subcategoryService;

        public ProductController()
        {
            _productService = new ProductService();
            _subcategoryService = new SubCategoryService();
        }
        
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }

        //Get olayı için
        public ActionResult Add()
        {
            ProductVM vm = new ProductVM();
            vm.AltKategoriler = _subcategoryService.GetActive();

            return View(vm);
        }

        //Post olayı için
        [HttpPost]
        public ActionResult Add(Product model,HttpPostedFileBase Image)
        {
            ImageUploader.UploadImage("/Uploads/", Image);
            return View();
        }
    }
}