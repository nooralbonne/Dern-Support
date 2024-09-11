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
        
        // Add Logout 
        Task Logout();

        // add user profile 
        public Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal);

    }
}
