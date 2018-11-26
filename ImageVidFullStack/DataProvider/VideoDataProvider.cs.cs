using Dapper;
using ImageVidFullStack.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ImageVidFullStack.DataProvider
{
    public class VideoDataProvider : IVideoDataProvider
    {
        private readonly string connectionString = "Server=SKYCOMDEV01;Database=PVP;Trusted_Connection=True;;Connection Timeout=3000";
        private readonly PVPContext _PVPContext;
        private readonly SqlConnection sqlConnection;

        public async Task AddFile(byte[] Ba, string FileName, string ContentType)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {

                await sqlConnection.OpenAsync();
                var a = sqlConnection.ConnectionTimeout;
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@fileName", FileName);
                dynamicParameters.Add("@contentType", ContentType);
                dynamicParameters.Add("@data", Ba);

                await sqlConnection.ExecuteAsync(
                    "spAddVideo",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }

        }

        public async Task UpdateFile(CatSubCatVideoModel cat)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@cat_id", cat.catid);
                parameters.Add("@subCat_Id", cat.subcatid);
                parameters.Add("@fileName", cat.filename);

                await sqlConnection.ExecuteAsync(
                    "spUpdateVideoCat",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


        //all

        public async Task<IEnumerable<VideoList>> GetVideos(int catId, int subcatId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@catid", catId);
                parameters.Add("@subcatid", subcatId);
                return await sqlConnection.QueryAsync<VideoList>(
                    "spGetVideos",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                //return await _PVPContext.Category.Select("spGetUsers").ToArrayAsync();
                // return null; 

            }
        }

        public VideoModel Getvideo(int Vid)
        {
            return getTestData(Vid);
            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.OpenAsync();
            //    var parameters = new DynamicParameters();
            //    parameters.Add("@vidid", Vid);
            //    VideoModel x = await sqlConnection.QuerySingleOrDefaultAsync<VideoModel>("spGetOneVideo",
            //         parameters,
            //         commandType: CommandType.StoredProcedure);

            //return x;


            //}
        }

        private VideoModel getTestData(int Vid)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@vidid", Vid);
                VideoModel x = sqlConnection.QuerySingle<VideoModel>("spGetOneVideo",
                     parameters,
                     commandType: CommandType.StoredProcedure);

                return x;


            }
        }

        // delete
        public async Task DeleteVid(int VidId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@VidId", VidId);
                await sqlConnection.ExecuteAsync("spDeleteVideo", parameters, commandType: CommandType.StoredProcedure);
            }

        }

    }
}
