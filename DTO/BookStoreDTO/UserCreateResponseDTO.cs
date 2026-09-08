using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTests.DTO.BookStoreDTO
{
    public record UserCreateResponseDTO(
        string UserId,
        string UserName,
        List<UserCreateResponseBookDTO> Books
    );
}