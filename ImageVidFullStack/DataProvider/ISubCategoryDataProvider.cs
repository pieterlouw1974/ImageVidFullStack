using ImageVidFullStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageVidFullStack.DataProvider
{
    public interface ISubCategoryDataProvider
    {
        Task<IEnumerable<SubCategory>> GetSubCategorys();

        Task<IEnumerable<SubCategory>> GetSubCategory(int CatId);

        Task AddSubCategory(SubCategory SubCat);

        Task UpdateSubCategory(SubCategory SubCat);

        Task DeleteSubCategory(int CatId);
    }
}
