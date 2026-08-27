using System.Text.Json.Serialization;

namespace ApiTests.DTO.ProfileUsersDTO;

public record GeoDTO(
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng
);