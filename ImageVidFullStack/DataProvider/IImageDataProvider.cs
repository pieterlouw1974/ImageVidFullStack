using ImageVidFullStack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageVidFullStack.DataProvider
{
    public interface IImageDataProvider
    {
        Task<IEnumerable<ImageList>> GetImages(int CatId, int subcatId);

        Task<Image> GetImage(int imgId);

        Task AddImage(Image Cat);

        Task UpdateImage(Image Cat);

        Task DeleteImg(int ImgId);
    }
}
