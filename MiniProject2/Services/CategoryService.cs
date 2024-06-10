using MiniProject2.Models;
using MiniProject2.Repositories;

namespace MiniProject2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _repo;
        public CategoryService(ICategoryRepo repo)
        {
            _repo = repo;
        }

        public int AddCategory(Category category)
        {
            return _repo.AddCategory(category);
        }

        public int DeleteCategory(int id)
        {
            return (_repo.DeleteCategory(id));
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repo.GetAllCategories();

        }

        public Category GetCategoryById(int id)
        {
            return _repo.GetCategoryById(id);
        }

        public int UpdateCategory(Category category)
        {
            return _repo.UpdateCategory(category);

        }
    }
}
