using System;
using System.Collections.Generic;
using System.Text;
using ApiTests.Interfaces.DapperTestsInterfaces;
using ApiTests.DTO.DapperTestsDTO;
using Microsoft.Data.Sqlite;
using Dapper;

namespace ApiTests.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connection;

        public ProductRepository(string connection)
        {
            this._connection = connection;
        }

        public async Task<ProductDTO> GetProductAsync(int id)
        {
            await using var db = new SqliteConnection(_connection);
            var product = await db.QueryFirstOrDefaultAsync<ProductDTO>("SELECT * from Products " +
                                                                         "WHERE Id = @id", new { id });
            return product;
        }
    }
}