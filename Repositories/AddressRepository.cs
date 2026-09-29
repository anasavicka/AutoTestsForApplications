using Dapper;
using Microsoft.Data.Sqlite;
using ApiTests.DTO.DapperTestsDTO;
using ApiTests.Interfaces.DapperTestsInterfaces;

namespace ApiTests.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string _connection;

        public AddressRepository(string connection)
        {
            this._connection = connection;
        }

        public async Task<AddressDTO> GetAddressByUserId(int userId)
        {
            using var db = new SqliteConnection(_connection);
            var address = await db.QueryFirstOrDefaultAsync<AddressDTO>("SELECT * from Addresses " +
                                                                        "WHERE UserId = @userId", new { userId });
            return address;
        }

        async public Task<IEnumerable<string>> GetDistinctCitiesByCategoryAsync(string categoryName)
        {
            await using var db = new SqliteConnection(_connection);
            var cities = await db.QueryAsync<string>(
                "SELECT DISTINCT Addresses.City " +
                "FROM Categories " +
                "JOIN Products ON Categories.Id = Products.CategoryId " +
                "JOIN OrderItems ON Products.Id = OrderItems.ProductId " +
                "JOIN Orders ON OrderItems.OrderId = Orders.Id " +
                "JOIN Addresses ON Orders.UserId = Addresses.UserId " +
                "WHERE Categories.Name = @categoryName",
                new { categoryName });
            return cities;
        }
    }
}