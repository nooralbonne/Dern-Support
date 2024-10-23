using Dern_Support.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IUser
    {
        // Add Register 
        Task<UserDto> Register(RegisterdUserDto registerdUserDto, ModelStateDictionary modelState);

        // Add login 
        public Task<UserDto> UserAuthentication(string username, string password);

        Task<string> GenerateJwtToken(UserDto user); // Add this method

        // Add Logout 
        Task Logout();

        // add user profile 
        public Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal);

        // Retrieve all users
        Task<IEnumerable<UserDto>> GetAllUsers();

        // Retrieve a user by ID
        Task<UserDto> GetUserAccountById(string userId);

        // Update a user
        Task<UserDto> UpdateUser(string userId, UpdateUserDto updateUserDto);

        // Delete a user
        Task<bool> DeleteUser(string userId);



    }
}
