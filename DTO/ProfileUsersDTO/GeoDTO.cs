using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record GeoDTO(
    [property: JsonPropertyName("lat")] double lat,
    [property: JsonPropertyName("lng")] double lng
);