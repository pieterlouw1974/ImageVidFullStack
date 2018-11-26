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
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryDataProvider SubCategoryDataProvider;

        public SubCategoryController(ISubCategoryDataProvider subcategoryDataProvider)
        {
            this.SubCategoryDataProvider = subcategoryDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<SubCategory>> Get()
        {
            return await this.SubCategoryDataProvider.GetSubCategorys();
        }

        [HttpGet("{catid:int}")]
        public async Task<IEnumerable<SubCategory>> Get(int catid)
        {
            return await this.SubCategoryDataProvider.GetSubCategory(catid);
        }

        [HttpPost]
        public async Task Post([FromBody]SubCategory cat)
        {
            await this.SubCategoryDataProvider.AddSubCategory(cat);
        }

        [HttpPut("{UserId}")]
        public async Task Put(int id, [FromBody]SubCategory cat)
        {
            await this.SubCategoryDataProvider.UpdateSubCategory(cat);
        }

        [HttpDelete("{UserId}")]
        public async Task Delete(int catId)
        {
            await this.SubCategoryDataProvider.DeleteSubCategory(catId);

        }

    }
}
