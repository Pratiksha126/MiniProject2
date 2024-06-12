using MiniProject2.Data;
using MiniProject2.Models;

namespace MiniProject2.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _db;
        public ProductRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public int AddProduct(Product product)
        {
            _db.Products.Add(product);
            int res = _db.SaveChanges();
            return res;
            
        }

        public int DeleteProduct(int id)
        {
            int res = 0;
            var prod = _db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (prod != null)
            {
                _db.Products.Remove(prod);
                res = _db.SaveChanges();
            }
            return res;

            
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Products.ToList();

            
        }

        public Product GetProductById(int id)
        {
            var prod = _db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return prod;

           
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            var model = from p in _db.Products
                        where p.ProductName.Contains(name)
                        select p;
            return model;

            
        }

        public int UpdateProduct(Product product)
        {
            int res = 0;
            Product prod = new Product();
            prod = _db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Price = product.Price;
                prod.CategoryId = product.CategoryId;
                prod.ImageURL = product.ImageURL;
                prod.Description = product.Description;
                prod.Stock = product.Stock;
                prod.Discount = product.Discount;
                res = _db.SaveChanges();
            }
            return res;

        }
    }
}
