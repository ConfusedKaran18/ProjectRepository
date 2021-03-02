using GeekHub.Database;
using GeekHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GeekHub.Services
{
    public class ProductService
    {
        public void SaveProduct(Product product)
        {
            using (var context = new GeekHubContext())
            {
                context.Entry(product.ProductCategory).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();      //to enter in the database
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new GeekHubContext())
            {
                return context.Products.Include(x => x.ProductCategory).ToList();
            }
        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new GeekHubContext())
            {
                return context.Products.Where(x => IDs.Contains(x.ID)).ToList();
            }
        }

        public Product GetProduct(int ID)
        {
            using (var context = new GeekHubContext())
            {
                return context.Products.Find(ID);
            }
        }

        public void UpdateProduct(Product Product)
        {
            using (var context = new GeekHubContext())
            {
                context.Entry(Product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new GeekHubContext())
            {
                var Product = GetProduct(ID);
                context.Entry(Product).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> SearchProducts(string search)
        {
            using (var context = new GeekHubContext())
            {
                List<Product> searchResults = new List<Product>();
                var products = GetProducts();
                foreach (var p in products)
                {
                    if (p.Name != null && p.Name.ToLower().Contains(search.ToLower()))
                    {
                        searchResults.Add(p);
                    }
                }
                return searchResults;
            }
        }
    }
}
