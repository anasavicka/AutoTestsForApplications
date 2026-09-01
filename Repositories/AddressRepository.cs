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
    }
}