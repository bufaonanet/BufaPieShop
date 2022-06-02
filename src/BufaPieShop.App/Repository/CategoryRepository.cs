using BufaPieShop.App.Models;
using System.Collections.Generic;

namespace BufaPieShop.App.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> AllCategories => _dbContext.Categories;
    }
}
