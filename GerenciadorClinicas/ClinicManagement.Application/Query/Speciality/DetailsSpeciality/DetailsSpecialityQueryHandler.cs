using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Application.DTO.ViewModel.Speciality;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Speciality.DetailsSpeciality
{
    public class DetailsSpecialityQueryHandler : IHandler<DetailsSpecialityQuery, ResultViewModel<DetailsSpecialityDto>>
    {
        private readonly ISpecialtyRepository _specialityRepository;

        public DetailsSpecialityQueryHandler(ISpecialtyRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        public async Task<ResultViewModel<DetailsSpecialityDto>> HandlerAsync(DetailsSpecialityQuery request)
        {
            var speciality = await _specialityRepository.GetSpecialtyByIdAsync(request.Id);

            if (speciality == null)
            {
                return ResultViewModel<DetailsSpecialityDto>.Failure(
                    Error.NotFound(
                        "ClinicManagement.Application.Query.Speciality.DetailsSpeciality",
                        $"Especialidade com ID {request.Id} não encontrada"
                    )
                );
            }

            var dto = new DetailsSpecialityDto
            {
                Id = speciality.Id,
                CodeSpecialty = speciality.CodeSpecialty,
                NameSpeacialty = speciality.NameSpeacialty,
                MedicSpecialties = new List<MedicSpecialtyDto>()
            };

            return ResultViewModel<DetailsSpecialityDto>.Success(dto);
        }
    }
}
