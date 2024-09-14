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
        private readonly JwtTokenService _jwtTokenService; // Changed to readonly

        public IdentitiUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService; // Changed to readonly
        }

        // Register
        public async Task<UserDto> Register(RegisterdUserDto registerdUserDto, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email,
                FirstName = registerdUserDto.FirstName,
                LastName = registerdUserDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerdUserDto.Password);

            if (result.Succeeded)
            {
                if (registerdUserDto.Roles != null && registerdUserDto.Roles.Any())
                {
                    var roleResult = await _userManager.AddToRolesAsync(user, registerdUserDto.Roles);

                    if (roleResult.Succeeded)
                    {
                        return new UserDto
                        {
                            Id = user.Id,
                            Username = user.UserName,
                            Roles = await _userManager.GetRolesAsync(user)
                        };
                    }
                    else
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            modelState.AddModelError("Role", error.Description);
                        }
                    }
                }
                else
                {
                    modelState.AddModelError("Roles", "Roles are required.");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    var errorCode = error.Code.Contains("Password") ? nameof(registerdUserDto.Password) :
                                    error.Code.Contains("Email") ? nameof(registerdUserDto.Email) :
                                    error.Code.Contains("Username") ? nameof(registerdUserDto.UserName) : "";
                    modelState.AddModelError(errorCode, error.Description);
                }
            }

            return null;
        }


        // Login
        public async Task<UserDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return null;

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                var roles = await _userManager.GetRolesAsync(user);
                // Ensure roles are correctly populated
                Console.WriteLine("Roles: " + string.Join(", ", roles)); // Log roles for debugging

                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(30)),
                    Roles = roles // Make sure this is not null
                };
            }

            return null;
        }



        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            if (user == null) return null;

            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await _jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(30)), // Updated duration
                Roles = await _userManager.GetRolesAsync(user)
            };
        }

        public async Task<string> GenerateJwtToken(UserDto user)
        {
            var userFromDb = await _userManager.FindByIdAsync(user.Id); // Ensure user exists
            return await _jwtTokenService.GenerateToken(userFromDb, TimeSpan.FromMinutes(60));
        }
    }
}
