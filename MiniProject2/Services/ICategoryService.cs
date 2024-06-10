using MiniProject2.Models;

namespace MiniProject2.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category category);
        int UpdateCategory(Category category);
        int DeleteCategory(int id);
    }
}
