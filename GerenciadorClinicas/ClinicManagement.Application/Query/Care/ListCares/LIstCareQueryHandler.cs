using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.ViewModel.Care;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Care.ListCare
{
    public class LIstCareQueryHandler : IHandler<ListCareQuery, ResultViewModel<List<ListCareDto>>>
    {
        private readonly ICareRepository _careRepository;

        public LIstCareQueryHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }

        public async Task<ResultViewModel<List<ListCareDto>>> HandlerAsync(ListCareQuery request)
        {
            var cares = await _careRepository.GetAllCaresAsync();
            var CareDtos = cares.Select(c => new ListCareDto
            {
                IdPaciente = c.IdPaciente,
                PatientName = c.Patient.Name,
                IdService = c.IdService,
                ServiceName = c.Service.Name,
                IdMedic = c.IdMedic,
                MedicName = c.Medic.Name,
            }).ToList();
            return ResultViewModel<List<ListCareDto>>.Success(CareDtos);
        }
    }
}
