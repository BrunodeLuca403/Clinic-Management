using ClinicManagement.Application.Commands.Service.CreateService;
using ClinicManagement.Application.Commands.Service.DeleteService;
using ClinicManagement.Application.Common;
using ClinicManagement.Application.Query.Patient.ListPatient;
using ClinicManagement.Application.Query.Service.DetailsService;
using ClinicManagement.Application.Query.Service.ListService;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using ClinicManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Service")]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/list-services")]
        public async Task<IActionResult> ListServices(ListServiceQuery query)
        {
            var services = await _mediator.DispatchAsync<ListServiceQuery, ResultViewModel<List<ListServiceQueryHandler>>>(query);

            if (services == null)
                return NotFound();

            return Ok(services);
        }

        [HttpGet("/service-{id}")]
        public async Task<IActionResult> GetByIdService(DetailsServiceQuery query)
        {
            var service = await _mediator.DispatchAsync<DetailsServiceQuery, ResultViewModel<DetailsServiceQueryHandler>>(query);

            if (service == null)
                return NotFound();

            return Ok(service);
        }

        [HttpPost("/create-service")]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            var create = await _mediator.DispatchAsync<CreateServiceCommand, ResultViewModel<CreateServiceCommandHandler>>(command);

            if (create == null)
                return BadRequest();

            return Ok(create);
        }

        //[HttpPut("/update-service")]
        //public async Task<IActionResult> UpdateService(Service service)
        //{
        //    var id = await _mediator.DispatchAsync<, ResultViewModel<CreateServiceCommandHandler>>(command);
        //    service.UpdateService(service.Name, service.Descripton, service.Price, service.Duration);
        //    if (id == null)
        //        return NotFound();
        //    return Ok(id);
        //}

        [HttpDelete("/delete-service")]
        public async Task<IActionResult> Deleteervice(DeleteServiceCommand command)
        {
            var id = await _mediator.DispatchAsync<DeleteServiceCommand, ResultViewModel<DeleteServiceCommandHandler>>(command);

            if (id == null)
                return NotFound();

            return Ok(id);
        }

    }
}
