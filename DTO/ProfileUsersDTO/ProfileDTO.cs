using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record ProfileDTO(
    [property: JsonPropertyName("fullName")] string fullName,
    [property: JsonPropertyName("age")] int age,
    [property: JsonPropertyName("address")] AddressDTO address,
    [property: JsonPropertyName("tags")] List<string> tags
);