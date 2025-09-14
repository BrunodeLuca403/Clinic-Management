using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO;
using ClinicManagement.Core.Repository;
using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Care.CreateCare
{
    public class CreateCareCommandHadler : IHandler<CreateCareCommand, ResultViewModel<Guid>>
    {
        private readonly ICareRepository _careRepository;

        public CreateCareCommandHadler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(CreateCareCommand command)
        {
            try
            {
                var care = new ClinicManagement.Core.Entitys.Care(command.IdPaciente, command.IdService, command.IdMedic, command.Agreement, command.StartService, command.FinishService, command.TypeTreatment);
                await _careRepository.AddCareAsync(care);
                return ResultViewModel<Guid>.Success(care.Id);
            }
            catch(Exception ex)
            {
                return ResultViewModel<Guid>.Failure(Error.Failure("ClinicManagement.Application.Commands.Care.CreateCare", ex.Message));
            }
        }
    }
}
