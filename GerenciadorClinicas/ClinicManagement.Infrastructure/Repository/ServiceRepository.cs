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
    public class ServiceRepository : IServiceRepository
    {
        private readonly ClinicDbContext _db;

        public ServiceRepository(ClinicDbContext db)
        {
            _db = db;
        }

        public async Task<Service> AddServiceAsync(Service service)
        {
            var create = _db.AddAsync(service);
            await _db.SaveChangesAsync();
            return service;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _db.Services.AsNoTracking().Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(Guid id)
        {
            return await _db.Services.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<Service> UpdateServiceAsync(Service service)
        {
            var Find = await _db.Services.AsNoTracking().SingleOrDefaultAsync(s => s.Id == service.Id && !s.IsDeleted);
            var update = _db.Services.Update(Find);
            await _db.SaveChangesAsync();

            return service;
        }
    }
}
