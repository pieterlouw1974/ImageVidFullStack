using Dapper;
using ImageVidFullStack.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ImageVidFullStack.DataProvider
{
    public class ImageDataProvider : IImageDataProvider
    {
        private readonly string connectionString = "Server=SKYCOMDEV01;Database=PVP;Trusted_Connection=True;";
        private readonly PVPContext _PVPContext;
        private readonly SqlConnection sqlConnection;

        // get
        public async Task<Image> GetImage(int imgId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@imgid", imgId);
                return await sqlConnection.QuerySingleOrDefaultAsync<Image>("spGetOneImage",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        //all

        public async Task<IEnumerable<ImageList>> GetImages(int catId, int subcatId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@catid", catId);
                parameters.Add("@subcatid", subcatId);
                return await sqlConnection.QueryAsync<ImageList>(
                    "spGetImages",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                //return await _PVPContext.Category.Select("spGetUsers").ToArrayAsync();
                // return null; 

            }
        }

        // add
        public async Task AddImage(Image img)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@catid", img.CatId);
                dynamicParameters.Add("@subcatid", img.SubCatId);
                dynamicParameters.Add("@Name", img.Name);
                dynamicParameters.Add("@Ext", img.Ext);
                dynamicParameters.Add("@Size", img.Size);
                dynamicParameters.Add("@Data", img.Data);

                await sqlConnection.ExecuteAsync(
                    "spAddImage",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        // update
        public async Task UpdateImage(Image img)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@CatId", img.Name);

                await sqlConnection.ExecuteAsync(
                    "spUpdateCategory",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        // delete
        public async Task DeleteImg(int ImgId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@ImgId", ImgId);
                await sqlConnection.ExecuteAsync("spDeleteImage", parameters, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
