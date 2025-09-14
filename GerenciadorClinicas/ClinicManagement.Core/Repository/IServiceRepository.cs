using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Repository
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(Guid id);
        Task<Service> AddServiceAsync(Service service);
        Task<Service> UpdateServiceAsync(Service service);    }
}
