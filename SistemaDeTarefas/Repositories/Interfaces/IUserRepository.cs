using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> AddAsync(UserModel user);
        Task<UserModel> UpdateAsync(UserModel user, int id);
        Task<bool> DeleteAsync(int id);
    }
}
