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
    public class SubCategoryDataProvider : ISubCategoryDataProvider
    {
        private readonly string connectionString = "Server=SKYCOMDEV01;Database=PVP;Trusted_Connection=True;";
        private readonly PVPContext _PVPContext;
        private readonly SqlConnection sqlConnection;

        // get 
        public async Task<IEnumerable<SubCategory>> GetSubCategory(int CatId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@Catid", CatId);

                return await sqlConnection.QueryAsync<SubCategory>(
                    "spGetSubCategorys",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            }

            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
            //    await sqlConnection.OpenAsync();
            //    var parameters = new DynamicParameters();
            //    parameters.Add("@Catid", CatId);
            //    return await sqlConnection.QueryAsync<SubCategory>(
            //        "spGetSubCategorys",
            //        parameters,
            //        commandType: CommandType.StoredProcedure);

            //    //await sqlConnection.OpenAsync();
            //    //var parameters = new DynamicParameters();
            //    //parameters.Add("@Catid", CatId);
            //    //return await sqlConnection.QueryAsync<SubCategory>("spGetSubCategorys",
            //    //    parameters,
            //    //    commandType: CommandType.StoredProcedure);

            //    //await sqlConnection.OpenAsync();
            //    //var parameters = new DynamicParameters();
            //    //parameters.Add("@Catid", catId);
            //    //return await sqlConnection.QuerySingleOrDefaultAsync<SubCategory>("spGetSubCategorys",
            //    //    parameters,
            //    //    commandType: CommandType.StoredProcedure);

            //    //await sqlConnection.OpenAsync();
            //    //var parameters = new DynamicParameters();
            //    //parameters.Add("@Catid", catId);
            //    //return await sqlConnection.QuerySingleOrDefaultAsync<SubCategory>("spGetSubCategorys",
            //    //    parameters,
            //    //    commandType: System.Data.CommandType.StoredProcedure);
            //}
        }


        //all
        public async Task<IEnumerable<SubCategory>> GetSubCategorys()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<SubCategory>(
                    "spGetSubCategorys",
                    null,
                    commandType: CommandType.StoredProcedure);

                //return await _PVPContext.Category.Select("spGetUsers").ToArrayAsync();
                //return null;

            }
        }

        // add
        public async Task AddSubCategory(SubCategory cat)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", cat.Name);
                dynamicParameters.Add("@Catid", cat.Catid);


                await sqlConnection.ExecuteAsync(
                    "spAddSubCategory",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        // update
        public async Task UpdateSubCategory(SubCategory cat)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@CatId", cat.Name);

                await sqlConnection.ExecuteAsync(
                    "spUpdateSubCategory",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


        // delete
        public async Task DeleteSubCategory(int catId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@CatId", catId);
                await sqlConnection.ExecuteAsync("spDeleteSubCategory", parameters, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
