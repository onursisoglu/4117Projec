using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProject.Model.Entities;
using WebProject.Service.Option;
using WebProject.UI.Areas.Admin.Controllers;
using WebProject.UI.Utility;

namespace WebProject.UI.Controllers
{
    public class AuthController : BaseController
    {

        AppUserService _appuserService;
        public AuthController()
        {
            _appuserService = new AppUserService();
        }

        // GET: Auth
        //Giriş Sayfasını Göster
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser model)
        {
            AppUser kullanici = _appuserService.GetByDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.UserName, true);
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser model,HttpPostedFileBase userImage)
        {
            try
            {
               
                    model.ImagePath = ImageUploader.UploadImage("/UserUploads/", userImage);
                    if (model.ImagePath == "0" || model.ImagePath == "1")
                    {
                        model.ImagePath = "/Uploads/user-512.png";
                    }

                    _appuserService.Add(model);
                    ShowMessage(MessageType.Success, "Kayıt işleminiz başarılıdır.<a href='/Auth/Login'> Buraya tıklayarak </a> Login sayfasına gidebilirsiniz.", 10, true);
                   
                
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ShowMessage(MessageType.Warning, "Kayıt sırasında hata oluştu bilgileriniz kontrol ediniz.", 5, false);
                return View();
                
            }
            
           
        }







    }
}