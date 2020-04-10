using cm.blazorApp.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace cm.blazorApp.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int productId)
        {
            Product obj = new Product();
            return _db.Products.Include(u => u.Category).FirstOrDefault(u => u.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return _db.Products.Include(u=>u.Category).ToList();
        }

        public List<Category> GetCategoryList()
        {
            return _db.Categories.ToList();
        }

        public bool CreateProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            var existingProduct = _db.Products.FirstOrDefault(u => u.Id == product.Id);

            if (existingProduct != null)
            {
                if (product.Image == null)
                {
                    product.Image = existingProduct.Image;
                }
                _db.Products.Update(product);
                _db.SaveChanges();
            } 
            else
            {
                return false;
            }

            return true;
        }

        public bool DeleteProduct(Product product)
        {
            var existingProduct = _db.Products.FirstOrDefault(u => u.Id == product.Id);

            if (existingProduct != null)
            {
                _db.Products.Remove(product);
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
