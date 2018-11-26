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
    public class ImagesController : Controller
    {
        private readonly IImageDataProvider ImageDataProvider;

        public ImagesController(IImageDataProvider imageDataProvider)
        {
            this.ImageDataProvider = imageDataProvider;
        }

        [HttpGet("{catId},{subcatId}")]
        public async Task<IEnumerable<ImageList>> Get(int catId, int subcatId)
        {
            return await this.ImageDataProvider.GetImages(catId, subcatId);
        }

        [HttpGet("{imgId}")]
        public async Task<Image> Get(int imgId)
        {
            return await this.ImageDataProvider.GetImage(imgId);
        }

        [HttpPost]
        public async Task Post([FromBody]Image img)
        {
            if (img != null)
            {
                await this.ImageDataProvider.AddImage(img);
            }
        }

        [HttpPut("{UserId}")]
        public async Task Put(int id, [FromBody]Image img)
        {
            await this.ImageDataProvider.UpdateImage(img);
        }

        [HttpDelete("{ImgId}")]
        public async Task Delete(int ImgId)
        {
            await this.ImageDataProvider.DeleteImg(ImgId);

        }

    }
}
