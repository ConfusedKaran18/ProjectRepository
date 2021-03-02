using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekHub.Web.ViewModels
{
    public class newCategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}