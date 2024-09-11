using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Repositories.Services
{
    public class UserAccountServices : IUserAccount
    {
        private readonly DernSupportDbContext _context;

        public UserAccountServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccountDto> CreateUserAccount(UserAccountDto userAccountDto)
        {
            var userAccount = new UserAccount
            {
                Username = userAccountDto.Username,
                PasswordHash = "SomeHashFunction(userAccountDto.PasswordHash)", // Example, modify as needed
                Email = userAccountDto.Email,
                // Set other properties if needed
            };

            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();

            return new UserAccountDto
            {
                UserId = userAccount.UserId,
                Username = userAccount.Username,
                Email = userAccount.Email,
                Role = userAccount.Role, // Assuming Role is set somewhere
                CreatedDate = userAccount.CreatedDate // Assuming CreatedDate is set somewhere
            };
        }

        public async Task DeleteUserAccount(int id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount != null)
            {
                _context.UserAccounts.Remove(userAccount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserAccountDto>> GetAllUserAccounts()
        {
            return await _context.UserAccounts
                .Select(ua => new UserAccountDto
                {
                    UserId = ua.UserId,
                    Username = ua.Username,
                    Email = ua.Email,
                    Role = ua.Role, // Assuming Role is available
                    CreatedDate = ua.CreatedDate // Assuming CreatedDate is available
                }).ToListAsync();
        }

        public async Task<UserAccountDto> GetUserAccountById(int userId)
        {
            var userAccount = await _context.UserAccounts.FindAsync(userId);
            if (userAccount == null) return null;

            return new UserAccountDto
            {
                UserId = userAccount.UserId,
                Username = userAccount.Username,
                Email = userAccount.Email,
                Role = userAccount.Role, // Assuming Role is available
                CreatedDate = userAccount.CreatedDate // Assuming CreatedDate is available
            };
        }

        public async Task<UserAccountDto> UpdateUserAccount(int id, UserAccountDto userAccountDto)
        {
            var existingUserAccount = await _context.UserAccounts.FindAsync(id);
            if (existingUserAccount == null) return null;

            existingUserAccount.Username = userAccountDto.Username;
            existingUserAccount.PasswordHash = "SomeHashFunction(userAccountDto.PasswordHash)"; // Example, modify as needed
            existingUserAccount.Email = userAccountDto.Email;
            // Update other necessary properties here

            await _context.SaveChangesAsync();

            return new UserAccountDto
            {
                UserId = existingUserAccount.UserId,
                Username = existingUserAccount.Username,
                Email = existingUserAccount.Email,
                Role = existingUserAccount.Role, // Assuming Role is available
                CreatedDate = existingUserAccount.CreatedDate // Assuming CreatedDate is available
            };
        }
    }
}
