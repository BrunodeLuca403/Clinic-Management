using ClinicManagement.Application.Common;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using ClinicManagement.Core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Patient.UpdatePatient
{
    public class UpdatePatientCommandHandler : IHandler<UpdatePatientCommand, ResultViewModel<Guid>>
    {
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(UpdatePatientCommand command)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(command.Cpf);

            if (patient == null)
            {
                return ResultViewModel<Guid>.Failure(
                    Error.NotFound(
                        "ClinicManagement.Application.Commands.Patient.UpdatePatient",
                        "Paciente não encontrado!"
                    )
                );
            }

            patient.UpdatePatient(command.Email,
                                  command.TypeBlood,
                                  command.HeightPatient,
                                  command.Weight,
                                  new Address(command.Address.Street, command.Address.Number, command.Address.Complement, command.Address.Neighborhood, command.Address.State, command.Address.City, command.Address.ZipCode ),
                                  command.Fone);

            return ResultViewModel<Guid>.Success(command.Id);

        }
    }
}
