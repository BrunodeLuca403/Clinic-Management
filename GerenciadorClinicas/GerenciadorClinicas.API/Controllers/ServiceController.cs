using ClinicManagement.API.Context;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Service")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet("/list-services")]
        public async Task<IActionResult> ListServices()
        {
            var services = _serviceRepository.GetAllServicesAsync();

            if (services == null)
                return NotFound();

            return Ok(services);
        }

        [HttpGet("/service-{id}")]
        public async Task<IActionResult> GetByIdService(Guid id)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(id);
            if (service == null)
                return NotFound();
            return Ok(service);
        }

        [HttpPost("/create-service")]
        public async Task<IActionResult> CreateService(Service service)
        {
            var create = await _serviceRepository.AddServiceAsync(service);
            if (create == null)
                return BadRequest();
            return Ok(create);
        }

        [HttpPut("/update-service")]
        public async Task<IActionResult> UpdateService(Service service)
        {
            var id = await _serviceRepository.UpdateServiceAsync(service);
            service.UpdateService(service.Name, service.Descripton, service.Price, service.Duration);
            if (id == null)
                return NotFound();
            return Ok(id);
        }

        [HttpDelete("/delete-service")]
        public async Task<IActionResult> Deleteervice(Service service)
        {
            var id = await _serviceRepository.UpdateServiceAsync(service);
            service.SetAsDeleted();
            if (id == null)
                return NotFound();
            return Ok(id);
        }

    }
}
