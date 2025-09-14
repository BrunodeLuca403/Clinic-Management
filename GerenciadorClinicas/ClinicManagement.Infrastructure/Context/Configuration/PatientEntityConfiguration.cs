using ClinicManagement.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Context.Configuration
{
    public class PatientEntityConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.OwnsOne(p => p.Address);
            builder.HasMany(p => p.Cares).WithOne(p => p.Patient).HasForeignKey(p => p.IdPaciente).OnDelete(DeleteBehavior.Restrict);


            builder.Property(p => p.HeightPatient)
                   .HasPrecision(5, 2);
        }
    }
}
