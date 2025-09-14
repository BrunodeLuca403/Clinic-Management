using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Repository
{
    public interface ISpecialtyRepository 
    {
        Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync();
        Task<Specialty> GetSpecialtyByIdAsync(Guid id);
        Task<Specialty> AddSpecialtyAsync(Specialty specialty);
        Task<Specialty> UpdateSpecialtyAsync(Specialty specialty);
    }
}
