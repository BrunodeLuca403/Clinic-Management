using ClinicManagement.API.Context;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repository
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly ClinicDbContext _db;

        public SpecialtyRepository(ClinicDbContext db)
        {
            _db = db;
        }

        public async Task<Specialty> AddSpecialtyAsync(Specialty specialty)
        {
            var create = _db.AddAsync(specialty);   
            await _db.SaveChangesAsync();
            return specialty;
        }

        public async Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync()
        {
            return await _db.Specialties.AsNoTracking().Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Specialty> GetSpecialtyByIdAsync(Guid id)
        {
            return await _db.Specialties.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<Specialty> UpdateSpecialtyAsync(Specialty specialty)
        {
            var Find =  _db.Specialties.AsNoTracking().SingleOrDefault(s => s.Id == specialty.Id && !s.IsDeleted);
            var update = _db.Specialties.Update(Find);
            _db.SaveChangesAsync();
            return Find;
        }
    }
}
