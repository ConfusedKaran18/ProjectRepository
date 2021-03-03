using GeekHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeekHub.Database;
using System.Threading.Tasks;

namespace GeekHub.Services
{
    public class CategoryService
    {
        public void SaveCategory(Category category)
        {
            using (var context = new GeekHubContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();      //to enter in the database
            }
        }

        public List<Category> GetCategories()
        {
            using (var context = new GeekHubContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategory(int ID)
        {
            using (var context = new GeekHubContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new GeekHubContext())
            {
                return context.Categories.Where(x => x.IsFeatured && x.ImageURL != null).ToList();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new GeekHubContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new GeekHubContext())
            {
                var category = GetCategory(ID);
                context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Category> SearchCategories(string search)
        {
            using (var context = new GeekHubContext())
            {
                List<Category> searchResults = new List<Category>();
                var categories = GetCategories();
                foreach (var c in categories)
                {
                    if (c.Name != null && c.Name.ToLower().Contains(search.ToLower()))
                    {
                        searchResults.Add(c);
                    }
                }

                return searchResults;
            }
        }
    }
}
