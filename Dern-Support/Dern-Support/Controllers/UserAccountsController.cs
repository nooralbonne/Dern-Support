using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly IUserAccount _userAccountService;

        public UserAccountsController(IUserAccount userAccountService)
        {
            _userAccountService = userAccountService;
        }

        // GET: api/UserAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccountDto>>> GetUserAccounts()
        {
            var userAccounts = await _userAccountService.GetAllUserAccounts();
            return Ok(userAccounts);
        }

        // GET: api/UserAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccountDto>> GetUserAccount(int id)
        {
            var userAccount = await _userAccountService.GetUserAccountById(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            return Ok(userAccount);
        }

        // PUT: api/UserAccounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccount(int id, UserAccountDto userAccountDto)
        {
            if (id != userAccountDto.UserId)
            {
                return BadRequest();
            }

            var updatedUserAccount = await _userAccountService.UpdateUserAccount(id, userAccountDto);
            if (updatedUserAccount == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/UserAccounts
        [HttpPost]
        public async Task<ActionResult<UserAccountDto>> PostUserAccount(UserAccountDto userAccountDto)
        {
            var createdUserAccount = await _userAccountService.CreateUserAccount(userAccountDto);
            return CreatedAtAction("GetUserAccount", new { id = createdUserAccount.UserId }, createdUserAccount);
        }

        // DELETE: api/UserAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount(int id)
        {
            await _userAccountService.DeleteUserAccount(id);
            return NoContent();
        }
    }
}
