using ClinicManagement.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Context.Configuration
{
    public class ServiceEntityConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(s => s.Cares).WithOne(s => s.Service).HasForeignKey(s => s.IdService).OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.Price)
              .HasPrecision(18, 2);
        }
    }
}
