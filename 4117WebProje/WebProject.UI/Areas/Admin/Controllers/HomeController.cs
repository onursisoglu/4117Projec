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
        //Kategorileri Listeleme için kullanılacak
        public ActionResult Index()
        {
            return View();
        }

        // Kategori Ekleme için Sayfa Gösterelim
        public ActionResult KategoriEkle()
        {
            return View();
        }


        CategoryService _categoryService;
        public HomeController()
        {
            _categoryService = new CategoryService();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Category model)
        {
            _categoryService.Add(model);
            ShowMessage(Utility.MessageType.Success, "Kategori Başarılı bir şekilde eklendi", 5, true);
            return View();
        }
    }
}