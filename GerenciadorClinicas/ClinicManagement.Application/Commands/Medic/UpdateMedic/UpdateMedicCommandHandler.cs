using ClinicManagement.Application.Common;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using ClinicManagement.Core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Medic.UpdateMedic
{
    public class UpdateMedicCommandHandler : IHandler<UpdateMedicCommand, ResultViewModel<Guid>>
    {
        private readonly IMedicRepository _medicRepository;

        public UpdateMedicCommandHandler(IMedicRepository medicRepository)
        {
            _medicRepository = medicRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(UpdateMedicCommand command)
        {
            var medic = await _medicRepository.GetMedicByIdAsync(command.Id);

            if (medic == null)
            {
                return ResultViewModel<Guid>.Failure(
                    Error.NotFound(
                        "ClinicManagement.Application.Commands.Medic.UpdateMedic",
                        "Médico não encontrado!"
                    )
                );
            }

            medic.UpdateMedic(
                      command.Name,
                      command.LastName,
                      command.PhoneNumber,
                      command.Email,
                      command.Crm,
                      command.Uf,
                      new Address(
                          command.Address.Street,
                          command.Address.Number,
                          command.Address.Complement,
                          command.Address.Neighborhood,
                          command.Address.City,
                          command.Address.State,
                          command.Address.ZipCode
                      )
                  );

            await _medicRepository.UpdateMedicAsync(medic);

            return ResultViewModel<Guid>.Success(command.Id);
        }
    }
}
