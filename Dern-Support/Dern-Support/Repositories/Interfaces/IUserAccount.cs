using Dern_Support.Model.DTO;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IUserAccount
    {
        Task<UserAccountDto> CreateUserAccount(UserAccountDto userAccountDto);
        Task<List<UserAccountDto>> GetAllUserAccounts();
        Task<UserAccountDto> GetUserAccountById(int userId);
        Task<UserAccountDto> UpdateUserAccount(int id, UserAccountDto userAccountDto);
        Task DeleteUserAccount(int id);
    }
}
