using ImageVidFullStack.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageVidFullStack.DataProvider
{
    public interface IVideoDataProvider
    {
        Task AddFile(byte[] Ba, string FileName, string ContentType);

        Task UpdateFile(CatSubCatVideoModel Cat);

        Task<IEnumerable<VideoList>> GetVideos(int CatId, int subcatId);

        VideoModel Getvideo(int Vid);

        Task DeleteVid(int VidId);
    }
}
