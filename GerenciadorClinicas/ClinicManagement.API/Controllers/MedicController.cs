using ClinicManagement.API.Context;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Medic")]
    public class MedicController : ControllerBase
    {
        private readonly IMedicRepository _medicRepository;

        public MedicController(IMedicRepository medicRepository)
        {
            _medicRepository = medicRepository;
        }

        [HttpGet("/list-medics")]
        public async Task<IActionResult> ListMedics()
        {
            var medics = await _medicRepository.GetAllMedicsAsync();

            if (medics == null)
                return NotFound();

            return Ok(medics);
        }

        [HttpGet("/medic-{id}")] 
        public async Task<IActionResult> GetByIdMedic(Guid id)
        {
            var medic = await _medicRepository.GetMedicByIdAsync(id);

            if (medic == null)
                return NotFound();

            return Ok(medic);
        }

        [HttpPost("/create-medic")]
        public async Task<IActionResult> CreateMedic(Medic medic)
        {
            var create = await _medicRepository.AddMedicAsync(medic);

            if (create == null)
                return BadRequest();

            return Ok(create);

        }

        [HttpPut("/update-medic")]
        public async Task<IActionResult> UpdateMedic(Medic medic)
        {

            var id = await _medicRepository.UpdateMedicAsync(medic);

            if (id == null)
                return NotFound();

            return Ok(medic);
        }

        [HttpDelete("/delete-medic")]
        public async Task<IActionResult> DeleteMedic(Medic medic)
        {
            medic.SetAsDelete();

            var id = await _medicRepository.UpdateMedicAsync(medic);

            if (id == null)
                return NotFound();

            return Ok(medic);
        }

    }
}
