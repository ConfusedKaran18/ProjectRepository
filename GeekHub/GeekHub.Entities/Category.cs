using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHub.Entities
{
    public class Category : BaseClass
    {
        public List<Product> Product { get; set; }
    }
}
