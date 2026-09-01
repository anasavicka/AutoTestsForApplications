using ApiTests.DTO.DapperTestsDTO;

namespace ApiTests.Interfaces.DapperTestsInterfaces
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetProductAsync(int id);
    }
}