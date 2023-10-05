using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JobsDbContext dbContext;

        public UserRepository(JobsDbContext jobsDbContext)
        {
            dbContext = jobsDbContext;
        }
        public async Task<List<UserModel>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> AddAsync(UserModel user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateAsync(UserModel user, int id)
        {
            UserModel userById = await GetByIdAsync(id) ?? throw new Exception($"User Id: {id} not found!");
            userById.Name = user.Name;
            userById.Email = user.Email;

            await dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            UserModel userById = await GetByIdAsync(id);

            if (userById == null)
            {
                throw new Exception($"User Id: {id} not found!");
            }

            dbContext.Users.Remove(userById);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
