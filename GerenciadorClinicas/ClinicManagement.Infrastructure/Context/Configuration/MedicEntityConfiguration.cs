using ClinicManagement.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Context.Configuration
{
    public class MedicEntityConfiguration : IEntityTypeConfiguration<Medic>
    {
        public void Configure(EntityTypeBuilder<Medic> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(m => m.Address);
            builder.HasMany(m => m.Cares).WithOne(m => m.Medic).HasForeignKey(m => m.IdMedic).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
