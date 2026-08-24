using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record AddressDTO(
    [property: JsonPropertyName("street")] string street,
    [property: JsonPropertyName("city")] string city,
    [property: JsonPropertyName("geo")] GeoDTO geo
);
