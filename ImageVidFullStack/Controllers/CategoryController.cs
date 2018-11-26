using ImageVidFullStack.DataProvider;
using ImageVidFullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageVidFullStack.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryDataProvider CategoryDataProvider;

        public CategoryController(ICategoryDataProvider categoryDataProvider)
        {
            this.CategoryDataProvider = categoryDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await this.CategoryDataProvider.GetCategorys();
        }

        [HttpGet("{UserId}")]
        public async Task<Category> Get(int catid)
        {
            return await this.CategoryDataProvider.GetCategory(catid);
        }

        [HttpPost]
        public async Task Post([FromBody]Category cat)
        {
            await this.CategoryDataProvider.AddCategory(cat);
        }

        [HttpPut("{UserId}")]
        public async Task Put(int id, [FromBody]Category cat)
        {
            await this.CategoryDataProvider.UpdateCategory(cat);
        }

        [HttpDelete("{UserId}")]
        public async Task Delete(int catId)
        {
            await this.CategoryDataProvider.DeleteCategory(catId);

        }

    }
}
