using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.ViewModel.Medic;
using ClinicManagement.Application.DTO.ViewModel.Patient;
using ClinicManagement.Application.Query.Medic.ListMedic;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Patient.ListPatient
{
    public class ListPatientQueryHandler : IHandler<ListPatientQuery, ResultViewModel<List<ListPatientDto>>>
    {
        private readonly IPatientRepository _patientRepository;

        public ListPatientQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ResultViewModel<List<ListPatientDto>>> HandlerAsync(ListPatientQuery request)
        {
  
            var medics = await _patientRepository.GetAllPatientsAsync();
            var MedicDtos = medics.Select(c => new ListPatientDto
            {
                Name = c.Name,
                Fone = c.Fone,
                Email = c.Email,
                CPF = c.CPF
            }).ToList();
            return ResultViewModel<List<ListPatientDto>>.Success(MedicDtos);
        
        }
    }
}
