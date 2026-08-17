using System.Text.Json.Serialization;

namespace ApiTests.DTO
{
    public class UserDataDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public int LastName { get; set; }
    }
}
