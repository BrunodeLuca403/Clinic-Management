using ClinicManagement.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Context.Configuration
{
    public class MedicSpecialtyEntityConfiguration : IEntityTypeConfiguration<MedicSpecialty>
    {
        public void Configure(EntityTypeBuilder<MedicSpecialty> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Medic).WithMany(m => m.MedicSpecialties).HasForeignKey(m => m.MedicId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Specialty).WithMany(m => m.MedicSpecialties).HasForeignKey(m => m.SpecialtyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
