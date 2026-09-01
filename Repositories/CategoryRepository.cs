using Dapper;
using Microsoft.Data.Sqlite;
using ApiTests.DTO.DapperTestsDTO;
using ApiTests.Interfaces.DapperTestsInterfaces;

namespace ApiTests.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connection;
        public CategoryRepository(string connection)
        {
            this._connection = connection;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            await using var db = new SqliteConnection(_connection);
            var categories = await db.QueryAsync<CategoryDTO>("SELECT * from Categories");
            return categories;
        }
    }
}