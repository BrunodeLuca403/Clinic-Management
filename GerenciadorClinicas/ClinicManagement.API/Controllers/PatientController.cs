using ClinicManagement.Application.Commands.Patient.RegistePatient;
using ClinicManagement.Application.Commands.Patient.UpdatePatient;
using ClinicManagement.Application.Common;
using ClinicManagement.Application.Query.Patient.DetailsPatient;
using ClinicManagement.Application.Query.Patient.ListPatient;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/list-patients")]
        public async Task<IActionResult> ListPatients(ListPatientQuery query)
        {
            var patients = await _mediator.DispatchAsync<ListPatientQuery, ResultViewModel<List<ListPatientQueryHandler>>>(query);

            if (patients == null)
                return NotFound();

            return Ok(patients);
        }

        [HttpGet("/patient-{id}")]
        public async Task<IActionResult> GetByIdPatient(DetailsPatientQuery query)
        {
            var patient = await _mediator.DispatchAsync<DetailsPatientQuery, ResultViewModel<DetailsPatientQueryHandler>>(query);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost("/create-patient")]
        public async Task<IActionResult> CreatePatient(RegisterPatientCommand commad)
        {
            var create = await _mediator.DispatchAsync<RegisterPatientCommand, ResultViewModel<Guid>>(commad);

            if (create == null)
                return BadRequest();

            return Ok(create);
        }

        [HttpPut("/update-patient")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientCommand command)
        {
            var id = await _mediator.DispatchAsync<UpdatePatientCommand, ResultViewModel<Guid>>(command);

            if (id == null)
                return NotFound();

            return Ok(id);
        }
    }
}
