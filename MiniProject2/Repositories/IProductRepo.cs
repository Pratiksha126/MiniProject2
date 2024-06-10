using MiniProject2.Models;

namespace MiniProject2.Repositories
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
        IEnumerable<Product> GetProductByName(string name);

    }
}
