using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record ProfileDTO(
    [property: JsonPropertyName("fullName")] string FullName,
    [property: JsonPropertyName("age")] int Age,
    [property: JsonPropertyName("address")] AddressDTO Address,
    [property: JsonPropertyName("tags")] List<string> Tags
);