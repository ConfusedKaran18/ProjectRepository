using GeekHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekHub.Web.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Product> CartProducts { get; set; }
    }
}