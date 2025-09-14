using ClinicManagement.API.Context;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicDbContext _db;
        public PatientRepository(ClinicDbContext context)
        {
            _db = context;
        }
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            var create = await _db.AddAsync(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _db.Patients.Where(p => !p.IsDelete).AsNoTracking().ToListAsync(); 
        }

        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            return await _db.Patients.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id && !p.IsDelete);
        }

        public Task<Patient> UpdatePatientAsync(Patient patient)
        {
            var id = _db.Patients.AsNoTracking().SingleOrDefaultAsync(p => p.Id == patient.Id && !p.IsDelete);
             _db.Patients.Update(patient);
            _db.SaveChangesAsync();
            return id;
        }
    }
}
