using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Model.Context;
using WebProject.Model.Entities;
using WebProject.Service.Option;

namespace WebProject.UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        CategoryService _categoryService;
        public HomeController()
        {
            _categoryService = new CategoryService();
        }


        //Kategorileri Listeleme için kullanılacak
        public ActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        // Kategori Ekleme için Sayfa Gösterelim
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Category model)
        {
            _categoryService.Add(model);
            ShowMessage(Utility.MessageType.Success, "Kategori Başarılı bir şekilde eklendi", 5, true);
            return View();
        }


        //Index sayfasından listeden seçili kategorinin id si gelecek ve kullanıcıya o kategorinin güncelleme için olan sayfasını göstereceğiz.
        public ActionResult Guncelle(Guid id)
        {
            Category secilenKat = _categoryService.GetByID(id);
            return View(secilenKat);

        }


        [HttpPost]
        public ActionResult Guncelle(Category model)
        {
            try
            {
                Category guncellencekKat = _categoryService.GetByID(model.ID);
                _categoryService.Update(model);
                ShowMessage(Utility.MessageType.Success, "Güncelleme Başarılı", 3, true);
            }
            catch (Exception ex)
            {
                ShowMessage(Utility.MessageType.Danger, "Güncelleme sırasında hata olıştu", 3, false);
            }

          return RedirectToAction("Index", "Home");
           
        }


        public ActionResult Sil(Guid id)
        {
            bool sonuc = _categoryService.Remove(id);

            if (sonuc)
            {
                ShowMessage(Utility.MessageType.Success, "Silme işlemi başarılıdır", 3, true);
            }
            else
            {
                ShowMessage(Utility.MessageType.Danger, "Silme işlemi hatalıdır", 5, false);
            }

            return RedirectToAction("Index", "Home");

        }


    }
}