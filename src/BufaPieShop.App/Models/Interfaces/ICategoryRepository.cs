using System.Collections.Generic;

namespace BufaPieShop.App.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }

    }


}
