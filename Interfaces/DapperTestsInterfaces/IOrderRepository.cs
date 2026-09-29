using ApiTests.DTO.DapperTestsDTO;

namespace ApiTests.Interfaces.DapperTestsInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderDTO> GetOrderAsync(int orderId, int UserId);
        Task<IEnumerable<OrderItemsDTO>> GetOrderItemsAsync(int orderId);
        Task<IEnumerable<long>> GetUsersIdByCategoryAsync(int categoryId);
    }
}