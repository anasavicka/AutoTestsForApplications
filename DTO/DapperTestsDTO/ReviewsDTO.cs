namespace ApiTests.DTO.DapperTestsDTO
{
    public record ReviewsDTO(
        long id,
        string userId,
        string productId,
        long rating,
        long comment,
        long createdAt
    );
}