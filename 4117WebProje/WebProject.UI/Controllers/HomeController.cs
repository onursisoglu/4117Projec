using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Service.Option;

namespace WebProject.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult _CategoryList()
        {
            CategoryService _catService = new CategoryService();

            return PartialView(_catService.GetActive());
        }




    }
}