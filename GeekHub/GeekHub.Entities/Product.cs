using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHub.Entities
{
    public class Product : BaseClass
    {
        public virtual Category ProductCategory { get; set; }
        public decimal Price { get; set; }
    }
}
