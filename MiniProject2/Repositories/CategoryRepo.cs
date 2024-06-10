using MiniProject2.Data;
using MiniProject2.Models;

namespace MiniProject2.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepo(ApplicationDbContext db)
        {
            _db = db;
        }


        public int AddCategory(Category category)
        {
            _db.Categories.Add(category);
            var res = _db.SaveChanges();
            return res;

            
        }

        public int DeleteCategory(int id)
        {
            int res = 0;
            var category = _db.Categories.Where(x => x.categoryId == id).FirstOrDefault();
            if (category != null)
            {
                _db.Categories.Remove(category);
                res = _db.SaveChanges();
            }
            return res;

        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _db.Categories.ToList();

        }

        public Category GetCategoryById(int id)
        {
            var category = _db.Categories.Where(x => x.categoryId == id).FirstOrDefault();
            return category;

        }

        public int UpdateCategory(Category category)
        {
            int res = 0;
            var c = _db.Categories.Where(x => x.categoryId == category.categoryId).FirstOrDefault();
            if (c != null)
            {
                c.categoryName = category.categoryName;
                res = _db.SaveChanges();
            }
            return res;

            
        }
    }
}
