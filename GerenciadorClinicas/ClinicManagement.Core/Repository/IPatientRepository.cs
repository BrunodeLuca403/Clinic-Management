using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(Guid id);
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
    }
}
