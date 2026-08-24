using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record UsersDataDTO(
    [property: JsonPropertyName("data")] List<UsersDTO> Data
);