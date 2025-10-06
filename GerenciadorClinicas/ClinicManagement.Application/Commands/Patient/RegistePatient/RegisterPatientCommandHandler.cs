using ClinicManagement.Application.Common;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Patient.RegistePatient
{
    public class RegisterPatientCommandHandler : IHandler<RegisterPatientCommand, ResultViewModel<Guid>>
    {
        private readonly IPatientRepository _patientRepository;

        public RegisterPatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(RegisterPatientCommand command)
        {
            try
            {
                var medic = new Core.Entitys.Patient(command.Name, command.LastName, command.Bithdate, command.Fone, command.Email, command.CPF ,command.TypeBlood, command.HeightPatient, command.Weight);
                await _patientRepository.AddPatientAsync(medic);
                return ResultViewModel<Guid>.Success(medic.Id);
            }
            catch (Exception ex)
            {
                return ResultViewModel<Guid>.Failure(Error.Failure("ClinicManagement.Application.Commands.Patient.RegistePatient", ex.Message));
            }
        }
    }
}
