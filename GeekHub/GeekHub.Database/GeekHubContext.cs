using GeekHub.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHub.Database
{
    public class GeekHubContext : DbContext, IDisposable
    {
            public GeekHubContext() : base("GeekHubConnection")  //overiding the on model creating; base
            {

            }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }
    }
}
