using System.Text.Json.Serialization;


namespace ApiTests.DTO
{
    public class CreateUserRequestDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }
    }
}
