using Dern_Support.Model.DTO;
using Dern_Support.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // POST: api/Admin/CreateUser
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] AdminUserCreationDTO adminUserDto)
        {
            if (adminUserDto == null)
                return BadRequest("Invalid user data.");

            var user = new ApplicationUser
            {
                UserName = adminUserDto.Username,
                Email = adminUserDto.Email,
                FirstName = adminUserDto.FirstName,
                LastName = adminUserDto.LastName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, adminUserDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Check if the role exists before assigning
            if (!await _roleManager.RoleExistsAsync(adminUserDto.Role))
                return BadRequest("Specified role does not exist.");

            // Assign the user to the role
            var roleResult = await _userManager.AddToRoleAsync(user, adminUserDto.Role);
            if (!roleResult.Succeeded)
                return BadRequest("Failed to assign role.");

            return Ok("User created and role assigned successfully.");
        }
    }
}
