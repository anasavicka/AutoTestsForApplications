using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record AddressDTO(
    [property: JsonPropertyName("street")] string Street,
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("geo")] GeoDTO Geo
);
