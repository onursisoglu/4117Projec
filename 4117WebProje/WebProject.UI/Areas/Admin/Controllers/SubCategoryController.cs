using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Model.Entities;
using WebProject.Service.Option;
using WebProject.UI.Areas.Admin.Models.ViewModels;

namespace WebProject.UI.Areas.Admin.Controllers
{
    public class SubCategoryController : BaseController
    {
        CategoryService _categoryService;
        SubCategoryService _subcategoryService;

        public SubCategoryController()
        {
            _categoryService = new CategoryService();
            _subcategoryService = new SubCategoryService();
        }



        // GET: Admin/SubCategory
        public ActionResult Index()
        {
            return View(_subcategoryService.GetAll());
        }


        public ActionResult Add()
        {

            return View(_categoryService.GetActive());
        }

        [HttpPost]
        public ActionResult Add(SubCategory model)
        {
            _subcategoryService.Add(model);
            return View(_categoryService.GetActive());
        }


        public ActionResult Delete(Guid id)
        {
           bool sonuc =  _subcategoryService.Remove(id);
            if (sonuc)
            {
                ShowMessage(Utility.MessageType.Success, "Silme başarılıdır", 3, true);
            }
            else
            {
                ShowMessage(Utility.MessageType.Danger, "Silme hatalıdır", 3, false);
            }

            return RedirectToAction("Index", "SubCategory");

        }

        //HttpGet sayfayı gösterecek
        public ActionResult Update(Guid id)
        {
            //Sayfaya 2 model gidecek . biri Kategori Listesi , biri güncellenecek verinin kendisidir.
            //Bu yüzden Admin Areasında viewModel class'ı açtık
            SubCategoryVM vm = new SubCategoryVM();
            vm.KatListesi = _categoryService.GetActive();

            //sayfayada güncellenecek veriyi önce veritabanından buluyoruz.
            SubCategory orjVeri = _subcategoryService.GetByID(id);

            vm.ID = orjVeri.ID;
            vm.Name = orjVeri.Name;
            vm.Description = orjVeri.Description;
            vm.CategoryID = orjVeri.CategoryID;

            return View(vm);

        }


        //HttpPost sayfadan verileri yakalayacak
        [HttpPost]
        public ActionResult Update(SubCategory model)
        {
            _subcategoryService.Update(model);
            return RedirectToAction("Index", "SubCategory");
        }
    }
}