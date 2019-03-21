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
            try
            {
               model.ImagePath=ImageUploader.UploadImage("/Uploads/", Image);
                if (model.ImagePath == "0" || model.ImagePath == "2")
                {
                    model.ImagePath = "/Uploads/user-512.png";
                }

                _productService.Add(model);
                ShowMessage(MessageType.Success, "Ürün başarılı bir şekilde eklendi", 3, true);
            }
            catch (Exception)
            {

                ShowMessage(MessageType.Danger, "Ürün eklenemedi bir hata oluştu", 3, true);
            }

            return Redirect("/Admin/Product/Index");
        }

        //Get olayı için
        public ActionResult Update(Guid id)
        {
            ProductVM vm = new ProductVM();
            vm.AltKategoriler = _subcategoryService.GetActive();

            Product bulunanUrun = _productService.GetByID(id);

            vm.ID = bulunanUrun.ID;
            vm.Name = bulunanUrun.Name;
            vm.Price = bulunanUrun.Price;
            vm.UnitsInStock = bulunanUrun.UnitsInStock;
            vm.SubCategoryID = bulunanUrun.SubCategoryID;
            vm.ImagePath = bulunanUrun.ImagePath;

            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(Product model,HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    model.ImagePath = ImageUploader.UploadImage("/Uploads/", Image);
                    if (model.ImagePath == "0" || model.ImagePath == "2")
                    {
                        model.ImagePath = "/Uploads/user-512.png";
                    }
                }
                _productService.Update(model);
                ShowMessage(MessageType.Success, "Ürün Güncellendi", 3, true);
            }
            catch (Exception)
            {

                ShowMessage(MessageType.Warning, "Ürün Güncellenemedi", 3, false);
            }

            return RedirectToAction("Index", "Product");

        }

    }
}