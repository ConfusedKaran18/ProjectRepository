using GeekHub.Entities;
using GeekHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekHub.Web.Controllers
{
    public class CategoryController : Controller    //Controller is from the MVC and cs file which inherits it behaves as a controller
    {
        CategoryService categoryService = new CategoryService();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        // GET: Category
        [HttpGet]   //get requests will be received here 
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]  //Any data sent ie post request will be received here
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]   //get requests will be received here 
        public ActionResult CategoryTable(string search)
        {
            var categories = categoryService.GetCategories();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    categories = categories.Where(c => c.Name != null && c.Name.ToLower().Contains(search.ToLower())).ToList();
            //}
            if (!string.IsNullOrEmpty(search))
            {
                categories = categoryService.SearchCategories(search);
            }
            return PartialView(categories);
        }

        [HttpGet]   //get requests will be received here 
        public ActionResult Edit(int ID)
        {
            var category = categoryService.GetCategory(ID);
            return PartialView(category);
        }

        [HttpPost]  //Any data sent ie post request will be received here
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("CategoryTable");
        }

        [HttpPost]  //Any data sent ie post request will be received here
        public ActionResult Delete(int ID)
        {
            categoryService.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
        }
    }
}