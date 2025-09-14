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
    public class CareRepository : ICareRepository
    {
        private readonly ClinicDbContext _db;

        public CareRepository(ClinicDbContext db)
        {
            _db = db;
        }

        public async Task<Care> AddCareAsync(Care care)
        {
            var created = await _db.Cares.AddAsync(care);
            _db.SaveChanges();
            return care;
        }

        public async Task<IEnumerable<Care>> GetAllCaresAsync()
        {
            return await _db.Cares.ToListAsync();
        }

        public async Task<Care> GetCareByIdAsync(Guid id)
        {
            return await _db.Cares.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Care> UpdateCareAsync(Care care)
        {
           var id = await _db.Cares.SingleOrDefaultAsync(c => c.Id == care.Id);
           care.UpdateCare(care.Agreement, care.StartService, care.FinishService);
           _db.Update(id);
           _db.SaveChanges();

            return id;
        }
    }
}
