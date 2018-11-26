using ImageVidFullStack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageVidFullStack.DataProvider
{
    public interface ICategoryDataProvider
    {
        Task<IEnumerable<Category>> GetCategorys();

        Task<Category> GetCategory(int CatId);

        Task AddCategory(Category Cat);

        Task UpdateCategory(Category Cat);

        Task DeleteCategory(int CatId);

    }
}
