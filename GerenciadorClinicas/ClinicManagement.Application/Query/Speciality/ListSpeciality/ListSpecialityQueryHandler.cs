using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.ViewModel.Speciality;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Speciality.ListSpeciality
{
    public class ListSpecialityQueryHandler : IHandler<ListSpecialityQuery, ResultViewModel<List<ListSpecialityDto>>>
    {
        private readonly ISpecialtyRepository _specialtyRepository;

        public ListSpecialityQueryHandler(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<ResultViewModel<List<ListSpecialityDto>>> HandlerAsync(ListSpecialityQuery request)
        {
            var specialties = await _specialtyRepository.GetAllSpecialtiesAsync();

            if(specialties == null)
            {
                return ResultViewModel<List<ListSpecialityDto>>.Failure(
                    Error.NotFound(
                        "ClinicManagement.Application.Query.Speciality.ListSpeciality",
                        "Nenhuma especialidade encontrada"
                    )
                );
            }

            var dto = specialties.Select(s => new ListSpecialityDto
            {
                Id = s.Id,
                CodeSpecialty = s.CodeSpecialty,
                NameSpeacialty = s.NameSpeacialty
            }).ToList();

           return ResultViewModel<List<ListSpecialityDto>>.Success(dto);
        }
    }
}
