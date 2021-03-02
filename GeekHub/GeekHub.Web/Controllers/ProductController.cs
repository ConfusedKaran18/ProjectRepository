using GeekHub.Entities;
using GeekHub.Services;
using GeekHub.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekHub.Web.Controllers
{
    public class ProductController : Controller    //Controller is from the MVC and cs file which inherits it behaves as a controller
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product
        [HttpGet]   //get requests will be received here 
        public ActionResult Create()
        {
            var categories = categoryService.GetCategories();
            return PartialView(categories);
        }

        [HttpPost]  //Any data sent ie post request will be received here
        public ActionResult Create(newCategoryViewModel model)
        {
            var product = new Product();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ProductCategory = categoryService.GetCategory(model.CategoryID);

            productService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]   //get requests will be received here 
        public ActionResult ProductTable(string search)
        {
            var products = productService.GetProducts();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    products = products.Where(c => c.Name != null && c.Name.ToLower().Contains(search.ToLower())).ToList();
            //}
            if (!string.IsNullOrEmpty(search))
            {
                products = productService.SearchProducts(search);
            }
            return PartialView(products);
        }

        [HttpGet]   //get requests will be received here 
        public ActionResult Edit(int ID)
        {
            var product = productService.GetProduct(ID);
            return PartialView(product);
        }

        [HttpPost]  //Any data sent ie post request will be received here
        public ActionResult Edit(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]  //Any data sent ie post request will be received here
        public ActionResult Delete(int ID)
        {
            productService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}