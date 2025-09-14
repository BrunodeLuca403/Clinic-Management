using ClinicManagement.API.Context;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController( IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet("/list-patients")]
        public async Task<IActionResult> ListPatients()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();

            if (patients == null)
                return NotFound();

            return Ok(patients);
        }

        [HttpGet("/patient-{id}")]
        public async Task<IActionResult> GetByIdPatient(Guid id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost("/create-patient")]
        public async Task<IActionResult> CreatePatient(Patient patient)
        {
            var create = await _patientRepository.AddPatientAsync(patient); 

            if (create == null)
                return BadRequest();

            return Ok(create);
        }

        [HttpPut("/update-patient")]
        public async Task<IActionResult> UpdatePatient(Patient patient)
        {
            var id = await _patientRepository.UpdatePatientAsync(patient);

            if (id == null)
                return NotFound();

            return Ok(id);
        }

        [HttpDelete("/delete-patient-{id}")]
        public async Task<IActionResult> DeletePatient(Patient patiente)
        {
            patiente.SetAsDeleted();
            var patient = await _patientRepository.UpdatePatientAsync(patiente);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }   
    }
}
