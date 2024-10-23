
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Register(RegisterdUserDto registerdUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors if ModelState is invalid
            }

            try
            {
                var user = await userService.Register(registerdUserDto, this.ModelState);

                if (user == null)
                {
                    return Conflict(new { message = "Registration failed. User may already exist." }); // User might already exist
                }

                return Ok(user); // Return the newly created user
            }
            catch (Exception ex)
            {
                // Log the exception details (you may want to use a logging framework)
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userService.UserAuthentication(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            return Ok(user);
        }

        [HttpPost("Logout")]
       
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return Ok(new { message = "User has been logged out successfully." });
        }


        [HttpGet("Profile")]
        public async Task<ActionResult<UserDto>> Profile()
        {
            var userProfile = await userService.userProfile(User);
            if (userProfile == null)
            {
                return NotFound(new { message = "User profile not found." });
            }
            return Ok(userProfile);
        }


        [HttpGet("AllUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            try
            {
                var users = await userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error getting users: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(string id)
        {
            var user = await userService.GetUserAccountById(id);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {id} not found." });
            }
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await userService.UpdateUser(id, updateUserDto);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {id} not found." });
            }
            return Ok(new { message = "User updated successfully.", user });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await userService.DeleteUser(id); // Ensure this is invoked

            if (!result)
            {
                return NotFound(new { message = $"User with ID {id} not found or could not be deleted." });
            }
            return NoContent(); // Successful deletion returns no content
        }
    }
}
