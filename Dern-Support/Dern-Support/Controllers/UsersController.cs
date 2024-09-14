using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser userService;

        public UsersController(IUser userService)
        {
            this.userService = userService;

        }

        [HttpPost("Register")]
        [AllowAnonymous] // Ensure this is added to make it public
        public async Task<ActionResult<UserDto>> Register(RegisterdUserDto registerdUserDto)
        {
            var user = await userService.Register(registerdUserDto, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }
            if (user == null)
            {
                return Unauthorized();
            }
            return BadRequest();
        }

        // login 
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userService.UserAuthentication(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);  // Make sure to return Ok(user) to include roles in response

        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return Ok(new { message = "User has been logged out successfully." });
        }

        [Authorize(Roles = "Admin")] // only logged in users can have access to the profile
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDto>> Profile()
        {
            return await userService.userProfile(User);
        }

    }
}