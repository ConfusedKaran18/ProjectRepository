using GeekHub.Services;
using GeekHub.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekHub.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CategoryService categoryService = new CategoryService();
            HomeViewModel featuredModel = new HomeViewModel();
            featuredModel.FeaturedCategories = categoryService.GetFeaturedCategories();
            return View(featuredModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}