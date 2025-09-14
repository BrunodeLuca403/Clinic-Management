using ClinicManagement.API.Context;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Specialty")]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyRepository _specialtyRepository;

        public SpecialtyController(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpGet("/list-specialtys")]
        public async Task<IActionResult> ListSpecialtys()
        {
            var specialtys = _specialtyRepository.GetAllSpecialtiesAsync();

            if (specialtys == null)
                return NotFound();

            return Ok(specialtys);
        }

        [HttpGet("/specialty-{id}")]
        public async Task<IActionResult> GetByIdSpecialty(Guid id)
        {
            var specialty = await _specialtyRepository.GetSpecialtyByIdAsync(id);

            if (specialty == null)
                return NotFound();

            return Ok(specialty);
        }

        [HttpPost("/create-specialty")]
        public async Task<IActionResult> CreateSpecialty(Specialty specialty)
        {
            var create = await _specialtyRepository.AddSpecialtyAsync(specialty);

            if (create == null)
                return BadRequest();

            return Ok(create);
        }

        [HttpPut("/update-specialty")]
        public async Task<IActionResult> UpdateSpecialty(Guid Id ,Specialty specialty)
        {
            var id = await _specialtyRepository.GetSpecialtyByIdAsync(Id);

            if (id == null)
                return NotFound();

            await _specialtyRepository.UpdateSpecialtyAsync(id);

            return Ok(id);
        }

        [HttpDelete("/delete-specialty-{id}")]
        public async Task<IActionResult> DeleteSpecialty(Guid Id, Specialty specialty)
        {
            var findSepeciality = await _specialtyRepository.GetSpecialtyByIdAsync(Id);

            if (findSepeciality == null)
                return NotFound();

            specialty.SetAsDelete();
            await _specialtyRepository.UpdateSpecialtyAsync(specialty);

            return Ok(specialty);
        }
    }
}
