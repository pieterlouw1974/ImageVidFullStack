using ImageVidFullStack.DataProvider;
using ImageVidFullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ImageVidFullStack.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private readonly IVideoDataProvider VideoDataProvider;

        public VideoController(IVideoDataProvider videoDataProvider)
        {
            this.VideoDataProvider = videoDataProvider;
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        //[RequestSizeLimit(40000000)]
        public async Task AddFile(IFormFile file)
        {

            if (file == null) throw new Exception("File is null");
            if (file.Length == 0) throw new Exception("File is empty");

            using (Stream stream = file.OpenReadStream())
            {
                using (var binaryReader = new BinaryReader(stream))
                {
                    var fileContent = binaryReader.ReadBytes((int)file.Length);
                    // await _uploadService.AddFile(fileContent, file.FileName, file.ContentType);
                    await this.VideoDataProvider.AddFile(fileContent, file.FileName, file.ContentType);
                }
            }
        }

        [HttpPut]
        public async Task Put([FromBody]CatSubCatVideoModel cat)
        {
            await this.VideoDataProvider.UpdateFile(cat);
        }

        [HttpGet("{catId},{subcatId}")]
        public async Task<IEnumerable<VideoList>> Get(int catId, int subcatId)
        {
            return await this.VideoDataProvider.GetVideos(catId, subcatId);
        }


        [HttpGet("{imgId}")]
        public async Task<IActionResult> Getvideo(int imgId)
        {
            var Vid = this.VideoDataProvider.Getvideo(imgId);
            Stream stream = new MemoryStream(Vid.Data);

            if (stream == null)
                return null;

            return File(stream, "application/octet-stream");
        }


        [HttpDelete("{VidId}")]
        public async Task Delete(int VidId)
        {
            await this.VideoDataProvider.DeleteVid(VidId);

        }

    }
}
