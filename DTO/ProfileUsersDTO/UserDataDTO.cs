using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record UserDataDTO(
    [property: JsonPropertyName("data")] List<UsersDTO> data
);