using ApiTests.DTO.DapperTestsDTO;

namespace ApiTests.Interfaces.DapperTestsInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByNameAndSurname(string firstName, string lastName);
    }
}