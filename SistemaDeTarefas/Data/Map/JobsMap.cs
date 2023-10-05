using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data.Map
{
    public class JobsMap : IEntityTypeConfiguration<JobsModel>
    {
        public void Configure(EntityTypeBuilder<JobsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User);
        }
    }
}
