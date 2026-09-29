namespace ApiTests.DTO.PetStoreDTO
{
    public record PaginationDTO(
        int Page,
        int Limit,
        int TotalItems,
        int TotalPages
    );
}