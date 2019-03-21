using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Model.Entities;
using WebProject.Service.Option;
using WebProject.UI.Utility;

namespace WebProject.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        // GET: Admin/AppUser
        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Index()
        {
            List<AppUser> kullanicilar = _appUserService.GetAll();

            return View(kullanicilar);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUser model,HttpPostedFileBase userImage)
        {
            model.ImagePath = ImageUploader.UploadImage("/UserUploads/", userImage);
            if (model.ImagePath == "0" || model.ImagePath == "1")
            {
                model.ImagePath = "/Uploads/user-512.png";
            }
            _appUserService.Add(model);
            return View();
        }

    }
}