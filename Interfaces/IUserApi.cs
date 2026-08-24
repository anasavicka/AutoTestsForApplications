using System;
using System.Collections.Generic;
using System.Text;
using ApiTests.DTO;
using Refit;

namespace ApiTests.Interfaces
{
    [Headers("x-api-key: free_user_3I3axJsumvjadwRLutWhk0EoQdj")]
    public interface IUserApi
    {
        [Get("/users/{id}")]
        Task<UserResponseDto> GetUserAsync(int id);

        [Post("/users")]
        Task<CreateUserResponseDto> CreateUserAsync([Body] CreateUserRequestDto request);

        [Delete("/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);
    }
}