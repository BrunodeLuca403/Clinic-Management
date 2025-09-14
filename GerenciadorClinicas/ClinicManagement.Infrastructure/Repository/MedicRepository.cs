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
    public class MedicRepository : IMedicRepository
    {
        private readonly ClinicDbContext _db;

        public MedicRepository(ClinicDbContext db)
        {
            _db = db;
        }

        public async Task<Medic> AddMedicAsync(Medic medic)
        {
              await _db.Medics.AddAsync(medic);   
            _db.SaveChanges();

            return medic;
        }

        public async Task DeleteMedicAsync(Guid id)
        {
            //var Id = await _db.Medics.SingleOrDefaultAsync(m => m.Id == id);
            //await _db.Medics.Remove(Id);
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Medic>> GetAllMedicsAsync()
        {
            return await _db.Medics.ToListAsync();  
        }

        public async Task<Medic> GetMedicByIdAsync(Guid id)
        {
            return await _db.Medics.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Medic> UpdateMedicAsync(Medic medic)
        {
            medic.UpdateMedic(medic.Name, medic.LastName, medic.PhoneNumber, medic.Email, medic.CRM, medic.Uf, medic.Address);
            var Id = await _db.Medics.SingleOrDefaultAsync(m => m.Id == medic.Id);
             _db.Medics.Update(Id);    
             _db.SaveChangesAsync();

            return Id;
        }
    }
}
