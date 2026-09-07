using ApiTests.DTO.DapperTestsDTO;

namespace ApiTests.Interfaces.DapperTestsInterfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    }
}