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
    public class CategoryDataProvider : ICategoryDataProvider
    {
        private readonly string connectionString = "Server=SKYCOMDEV01;Database=PVP;Trusted_Connection=True;";
        private readonly PVPContext _PVPContext;
        private readonly SqlConnection sqlConnection;

        // get
        public async Task<Category> GetCategory(int catId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", catId);
                return await sqlConnection.QuerySingleOrDefaultAsync<Category>("spGetUser",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        //all

        public async Task<IEnumerable<Category>> GetCategorys()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Category>(
                    "spGetCategorys",
                    null,
                    commandType: CommandType.StoredProcedure);

                //return await _PVPContext.Category.Select("spGetUsers").ToArrayAsync();
                // return null; 

            }
        }

        // add
        public async Task AddCategory(Category cat)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", cat.Name);


                await sqlConnection.ExecuteAsync(
                    "spAddCategory",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        // update
        public async Task UpdateCategory(Category cat)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@CatId", cat.Name);

                await sqlConnection.ExecuteAsync(
                    "spUpdateCategory",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


        // delete
        public async Task DeleteCategory(int catId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@CatId", catId);
                await sqlConnection.ExecuteAsync("spDeleteCategory", parameters, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
