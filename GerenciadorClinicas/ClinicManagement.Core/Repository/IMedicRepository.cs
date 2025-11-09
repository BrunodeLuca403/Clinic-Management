using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Repository
{
    public interface IMedicRepository
    {
        Task<IEnumerable<Medic>> GetAllMedicsAsync();
        Task<Medic> GetMedicByIdAsync(Guid id);
        Task<Medic> AddMedicAsync(Medic medic);
        Task<Medic> UpdateMedicAsync(Medic medic);
        Task DeleteMedicAsync(Guid id);
        Task<bool> ExistsByCrmAsync(string crm);

    }
}
