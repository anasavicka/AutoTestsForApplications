using System;
using System.Collections.Generic;
using System.Text;
using ApiTests.DTO.BookStoreDTO;
using Refit;

namespace ApiTests.Interfaces.BookStoreInterfaces
{
    public interface IBookStoreApi
    {
        [Post("/Account/v1/User")]
        Task<UserCreateResponseDTO> CreateUserAsync([Body] UserCredentialsDTO credentials);

        [Post("/Account/v1/GenerateToken")]
        Task<GenerateTokenResponseDTO> GenerateTokenAsync([Body] UserCredentialsDTO credentials);

        [Post("/Account/v1/Login")]
        Task<LoginUserResponseDTO> GetUserIdAsync([Body] UserCredentialsDTO credentials);

        [Get("/BookStore/v1/Books")]
        Task<BookListDTO> GetBookListAsync();

        [Get("/BookStore/v1/Book")]
        Task<UserCreateResponseBookDTO> GetBookByIsbnAsync([Query] string ISBN);

        [Post("/BookStore/v1/Books")]
        Task<UserCreateResponseDTO> AddBookToUserAsync([Body] AddCollectionOfBooksToUserDTO request,
            [Header("Authorization")] string token);

        [Delete("/BookStore/v1/Book")]
        Task<DeleteBookResponseDTO> DeleteBookFromUserAsync([Body] DeleteBookRequestDTO request, [Header("Authorization")] string token);
    }
}