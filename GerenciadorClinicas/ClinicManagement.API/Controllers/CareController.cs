using ClinicManagement.API.Context;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Care")]
    public class CareController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        private readonly ICareRepository _careRepository;
        public CareController(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }

        [HttpGet("/list-cares")]
        public async Task<IActionResult> ListCares()
        {
            var cares = await _careRepository.GetAllCaresAsync();
            return Ok(cares);
        }

        [HttpGet("/cares{id}")]
        public async Task<IActionResult> GetByIdCares(Guid id)
        {
            var care = await _careRepository.GetCareByIdAsync(id);  

            if (care == null)
            {
                return NotFound();
            }

            return Ok(care);
        }

        [HttpPost("/create-care")]
        public async Task<IActionResult> CreateCare(Care care)
        {
            var create = await _careRepository.AddCareAsync(care);

            if (create == null)
                return BadRequest();

            return Ok(create);
        }

        [HttpPut("/update-care")]
        public async Task<IActionResult> UpdateCare(Care care)
        {
            var id = await _careRepository.GetCareByIdAsync(care.Id);
            await _careRepository.UpdateCareAsync(care);

            if (id == null)
                return BadRequest();

            return Ok(id);
        }

        [HttpDelete("/delete-care")]
        public async Task<IActionResult> DeleteCare(Care care)
        {
            var id = await _careRepository.GetCareByIdAsync(care.Id);
            care.SetAsDeleted();
            _context.Update(id);

            if (id == null)
                return BadRequest();

            return Ok(id);
        }
    }
}
