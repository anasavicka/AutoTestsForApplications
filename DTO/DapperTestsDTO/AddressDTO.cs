namespace ApiTests.DTO.DapperTestsDTO
{
    public record AddressDTO(
        long id,
        long userId,
        string city,
        string street,
        string house,
        string apartment
    );
}