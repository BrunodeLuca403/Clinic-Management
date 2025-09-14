using ClinicManagement.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicManagement.API.Context
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
            
        }

        public DbSet<Care> Cares { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Anexo> Anexos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
