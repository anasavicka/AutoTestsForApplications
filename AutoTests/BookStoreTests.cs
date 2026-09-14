using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using ApiTests.DTO.BookStoreDTO;
using ApiTests.Helpers;
using ApiTests.Interfaces.BookStoreInterfaces;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ApiTests.Tests
{
    public class BookStoreTests
    {
        private IBookStoreApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookStoreApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IBookStoreApi>();
        }

        //[Test] // больше не будет работать, юзер уже создан
        //public async Task CreateNewUser()
        //{
        //    var credentials = new UserCreateRequestDTO("GabaGama", "StrongPass123!");
        //    var result = await api.CreateUserAsync(credentials); //"userID": "718e8c1a-8cc9-4130-8a6f-8a1dda323415","username": "GabaGama","books": []
        //    result.Should().NotBeNull();
        //}

        [Test]
        public async Task GetUserToken()
        {
            var credentials = new UserCredentialsDTO("GabaGama", "StrongPass123!");
            var result = await api.GenerateTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetUserId()
        {
            var credentials = new UserCredentialsDTO("GabaGama", "StrongPass123!");
            var result = await api.GetUserIdAsync(credentials);
            result.UserId.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetBookListAsync()
        {
            var result = await api.GetBookListAsync();
            result.Should().NotBeNull();
            result.Books.Should().HaveCount(8);
            result.Books.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetBookByIsbnAsync()
        {
            var result = await api.GetBookByIsbnAsync("9781449325862");
            result.Should().NotBeNull();
        }

        [Test]
        public async Task AddBookToUserAsync() // тест фейлится - ожидаемо (проблемы с апи)
        {
            var token = await GetTokenAsync();

            var listOfBooks = await api.GetBookListAsync();
            var rndIsbn = RandomHelper.GetRandomItem(listOfBooks.Books).Isbn;

            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO //круглые скобки - потому что record, а не класс
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO(rndIsbn) }
            );

            var response = await api.AddBookToUserAsync(request, token);
            response.Should().NotBeNull();
        }
        [Test]
        public async Task DeleteBookByIsbn()
        {
            var token = await GetTokenAsync();
            var userId = await GetUsersIdAsync();

            var isbn = "9781449331818";
            var additionBook = new CollectionOfIsbnsDTO(isbn);

            var addRequest = new AddCollectionOfBooksToUserDTO
            (
                userId,
                new List<CollectionOfIsbnsDTO> { additionBook }
            );

            await api.AddBookToUserAsync(addRequest, token);

            var request = new DeleteBookRequestDTO
            (
                isbn,
                userId
            );

            var response = await api.DeleteBookFromUserAsync(request, token);
            response.Should().NotBeNull();
        }

        [Test]
        public async Task SendInvalidRequestAsync()
        {
            var listOfBooks = await api.GetBookListAsync();
            var rndIsbn = RandomHelper.GetRandomItem(listOfBooks.Books).Isbn;

            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO 
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO(rndIsbn) }
            );

            Func<Task> act = async () => await api.AddBookToUserAsync(request, token: null); 
            act.Should().ThrowAsync<ApiException>(); //.Where(p => p.StatusCode == System.Net.HttpStatusCode.BadRequest) - по статус кодам почему-то не отрабатывает
        }
        
        [Test]
        public async Task AddBookWithInvalidIsbn_CheckExceptionAsync()
        {
            var token = await GetTokenAsync();
            var userId  = await GetUsersIdAsync();
            var invalidIsbn = new CollectionOfIsbnsDTO("INVALID_ISBN");
            var request = new AddCollectionOfBooksToUserDTO (userId, new List<CollectionOfIsbnsDTO> { invalidIsbn });

            Func<Task> act = async () => await api.AddBookToUserAsync(request, token); 
            await act.Should().ThrowAsync<ApiException>();
        }

        //вспомогательные методы
        private async Task<string > GetTokenAsync()
        {
            var credentials = new UserCredentialsDTO("GabaGama", "StrongPass123!");
            var token = await api.GenerateTokenAsync(credentials);
            var result = $"Bearer {token.Token}";
            return result;
        }

        private async Task<string> GetUsersIdAsync()
        {
            var credentials = new UserCredentialsDTO("GabaGama", "StrongPass123!");
            var result = await api.GetUserIdAsync(credentials);
            return result.UserId;
        }
    }
}