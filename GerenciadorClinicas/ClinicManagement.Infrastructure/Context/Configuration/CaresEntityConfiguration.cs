using ClinicManagement.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Context.Configuration
{
    public class CaresEntityConfiguration : IEntityTypeConfiguration<Care>
    {
        public void Configure(EntityTypeBuilder<Care> builder)
        {
            builder.HasKey(x => x.Id);  

            builder.HasOne(c => c.Patient).WithMany(p => p.Cares).HasForeignKey(c => c.IdPaciente).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Service).WithMany(s => s.Cares).HasForeignKey(c => c.IdService).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Medic).WithMany(m => m.Cares).HasForeignKey(c => c.IdMedic).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Anexos).WithOne(m => m.Care).HasForeignKey(c => c.Id).OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
