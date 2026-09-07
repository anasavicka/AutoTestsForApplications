using ApiTests.Interfaces.DapperTestsInterfaces;
using ApiTests.DTO.DapperTestsDTO;
using Microsoft.Data.Sqlite;
using Dapper;

namespace ApiTests.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connection;

        public OrderRepository(string connection)
        {
            this._connection = connection;
        }

        public async Task<OrderDTO> GetOrderAsync(int orderId, int userId)
        {
            await using var db = new SqliteConnection(_connection);
            var order = await db.QueryFirstOrDefaultAsync<OrderDTO>("SELECT * from Orders " +
                                                                    "WHERE Id = @orderId and UserId = @userId",
                new { orderId, userId });
            return order;
        }
        
        public async Task<IEnumerable<OrderItemsDTO>> GetOrderItemsAsync(int orderId)
        {
            await using var db = new SqliteConnection(_connection);
            var orderItems = await db.QueryAsync<OrderItemsDTO>("SELECT * from OrderItems "
                                                                + "WHERE OrderId = @orderId", new { orderId });
            return orderItems;
        }
    }
}