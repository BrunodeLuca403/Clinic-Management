using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Application.DTO.ViewModel.Medic;
using ClinicManagement.Application.DTO.ViewModel.Patient;
using ClinicManagement.Core.Enum;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Patient.DetailsPatient
{
    public class DetailsPatientQueryHandler : IHandler<DetailsPatientQuery, ResultViewModel<DetailsPatientDto>>
    {
        private readonly IPatientRepository _patientRepository;

        public DetailsPatientQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ResultViewModel<DetailsPatientDto>> HandlerAsync(DetailsPatientQuery query)
        {
            var medic = await _patientRepository.GetPatientByIdAsync(query.Cpf);

            if (medic == null)
            {
                return ResultViewModel<DetailsPatientDto>.Failure(
                    Error.NotFound(
                        "ClinicManagement.Application.Query.Patient.DetailsPatient",
                        $"CPF {query.Cpf} não encontrado"
                    )
                );
            }

            var dto = new DetailsPatientDto
            {
                Name = medic.Name,
                LastName = medic.LastName,
                Bithdate = medic.Bithdate,
                Fone = medic.Fone,
                Email = medic.Email,
                CPF = medic.CPF,
                TypeBlood = medic.TypeBlood,
                Weight = medic.Weight,
                Cares = new List<CareDto>(),
                Address = new AddressDto
                {
                    Street = medic.Address.Street,
                    Number = medic.Address.Number,
                    Complement = medic.Address.Complement,
                    City = medic.Address.City,
                    State = medic.Address.State,
                    ZipCode = medic.Address.ZipCode
                }
            };

            return ResultViewModel<DetailsPatientDto>.Success(dto);
        }
    }
}