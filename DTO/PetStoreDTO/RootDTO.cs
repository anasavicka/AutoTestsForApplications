namespace ApiTests.DTO.PetStoreDTO
{
    public record RootDTO(
        List<PetDTO> Data,
        PaginationDTO Pagination
    );

}