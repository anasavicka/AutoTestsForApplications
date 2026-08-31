using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ApiTests.DTO.ProfileUsersDTO;

namespace ApiTests.DTO.DapperTestsDTO
{
    public record UserDTO
    (
        long id,

        string firstName,

        string lastName,

        string email,

        string phone,

        string createdAt
    );
}