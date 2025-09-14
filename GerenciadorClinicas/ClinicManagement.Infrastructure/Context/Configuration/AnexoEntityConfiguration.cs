using ClinicManagement.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.API.Context.Configuration
{
    public class AnexoEntityConfiguration : IEntityTypeConfiguration<Anexo>
    {
        public void Configure(EntityTypeBuilder<Anexo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(a => a.Care).WithMany(a => a.Anexos).HasForeignKey(a => a.IdCare).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
