using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Repository
{
    public interface ICareRepository
    {
        Task<IEnumerable<Care>> GetAllCaresAsync();
        Task<Care> GetCareByIdAsync(Guid id);
        Task<Care> AddCareAsync(Care care);
        Task<Care> UpdateCareAsync(Care care);
    }
}
