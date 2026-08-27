using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record UsersDTO (
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("profile")] ProfileDTO Profile,
    [property: JsonPropertyName("roles")] List<string> Roles
);