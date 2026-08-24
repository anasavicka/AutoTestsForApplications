using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record UsersDTO (
    [property: JsonPropertyName("id")] int id,
    [property: JsonPropertyName("username")] string username,
    [property: JsonPropertyName("profile")] ProfileDTO profile,
    [property: JsonPropertyName("roles")] IReadOnlyList<string> roles
);