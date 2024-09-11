using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Dern_Support.Repositories.Services
{
    public class IdentitiUserService : IUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private JwtTokenService jwtTokenService;

        public IdentitiUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.jwtTokenService = jwtTokenService;
        }

        //Register
        public async Task<UserDto> Register(RegisterdUserDto registerdUserDto, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerdUserDto.Password);

            if (result.Succeeded)
            {
                // add roles to the new rigstred user
                await _userManager.AddToRolesAsync(user, registerdUserDto.Roles);

                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerdUserDto.Password) :
                                error.Code.Contains("Email") ? nameof(registerdUserDto.Email) :
                                error.Code.Contains("Username") ? nameof(registerdUserDto.UserName) : "";
                modelState.AddModelError(errorCode, error.Description);
            }

            return null;
        }

        //login
        public async Task<UserDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(7)),
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            return null;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async  Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(7)), // just for development purposes,
                        Roles = await _userManager.GetRolesAsync(user)

            };
        }
    }
}
  
  
