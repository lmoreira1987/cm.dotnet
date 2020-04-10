using cm.blazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cm.blazorApp.Services
{
    public class CategoriesService
    {
        private readonly ApplicationDbContext _db;

        public CategoriesService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int categoryId)
        {
            Category obj = new Category();
            return _db.Categories.FirstOrDefault(u => u.Id == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public bool CreateCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateCategory(Category category)
        {
            var existingCategory = _db.Categories.FirstOrDefault(u => u.Id == category.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                _db.SaveChanges();
            } 
            else
            {
                return false;
            }

            return true;
        }

        public bool DeleteCategory(Category category)
        {
            var existingCategory = _db.Categories.FirstOrDefault(u => u.Id == category.Id);

            if (existingCategory != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
