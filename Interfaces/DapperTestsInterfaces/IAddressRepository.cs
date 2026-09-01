using ApiTests.DTO.DapperTestsDTO;

namespace ApiTests.Interfaces.DapperTestsInterfaces
{
    public interface IAddressRepository
    {
        Task<AddressDTO> GetAddressByUserId(int userId);
    }
}