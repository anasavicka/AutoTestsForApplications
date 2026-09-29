using System.Collections.Generic;
using System.Text;

namespace ApiTests.DTO.BookStoreDTO
{
    public record DeleteBookRequestDTO(
        string Isbn,
        string UserId
    );
}