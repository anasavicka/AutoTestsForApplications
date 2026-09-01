namespace ApiTests.DTO.DapperTestsDTO
{
    public record UserDTO(
        long id,
        string firstName,
        string lastName,
        string email,
        string phone,
        string createdAt
    );
}