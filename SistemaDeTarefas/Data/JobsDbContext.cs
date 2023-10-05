using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<JobsModel> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new JobsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
