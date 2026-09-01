using System.Net.Http.Json;
using System.Text.Json;
using ApiTests.DTO;

namespace ApiTests.AutoTests
{
    public class UnitTest1
    {
        private static HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            };
            client.DefaultRequestHeaders.Add("x-api-key",
                "free_user_3I3axJsumvjadwRLutWhk0EoQdj"); // free_user_3Hs5R7VxAD3zzrYAcdt3Anqc5bY
        }

        [Test]
        public async Task Test1()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test2()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            string jsonGet = await response.Content.ReadAsStringAsync();
            UserResponseDto userResponse = JsonSerializer.Deserialize<UserResponseDto>(jsonGet);
            UserDataDto user = userResponse.Data;
        }

        [Test]
        public async Task Test3()
        {
            CreateUserRequestDto request = new CreateUserRequestDto
            {
                Name = "James Bond",
                Job = "Agent"
            };

            using HttpResponseMessage response = await client.PostAsJsonAsync("users", request);
            string jsonPost = await response.Content.ReadAsStringAsync();
            CreateUserResponseDto userResponse = JsonSerializer.Deserialize<CreateUserResponseDto>(jsonPost);
        }

        [Test]
        public async Task Test4()
        {
            CreateUserRequestDto request = new CreateUserRequestDto
            {
                Name = "James Bond",
                Job = "Agent007"
            };

            using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", request);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test5()
        {
            using HttpResponseMessage response = await client.DeleteAsync("users/2");

            response.EnsureSuccessStatusCode();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}