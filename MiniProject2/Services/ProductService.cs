using MiniProject2.Models;
using MiniProject2.Repositories;

namespace MiniProject2.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepo _repo;
        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }


        public int AddProduct(Product product)
        {
            return _repo.AddProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return (_repo.DeleteProduct(id));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();

           
        }

        public Product GetProductById(int id)
        {
            return _repo.GetProductById(id);
           
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return _repo.GetProductByName(name);

        }

        public int UpdateProduct(Product product)
        {
            return _repo.UpdateProduct(product);
        }
    }
}
