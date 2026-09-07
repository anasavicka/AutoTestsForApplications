using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTests.DTO.BookStoreDTO
{
    public record UserCredentialsDTO(
        string UserName,
        string Password
    );
}