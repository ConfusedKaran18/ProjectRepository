using GeekHub.Services;
using GeekHub.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekHub.Web.Controllers
{
    public class ShopController : Controller
    {
        CheckoutViewModel model = new CheckoutViewModel();
        ProductService productService = new ProductService();
        // GET: Shop
        public ActionResult Checkout()
        {
            var CartProductCookies = Request.Cookies["AddtoCart"];
            if (CartProductCookies != null)
            {
                var IDs = CartProductCookies.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = productService.GetProducts(IDs);
            }
            return PartialView(model);
        }

        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

    }
}