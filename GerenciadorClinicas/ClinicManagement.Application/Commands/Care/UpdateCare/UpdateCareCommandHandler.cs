using ClinicManagement.Application.Common;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Care.UpdateCare
{
    public class UpdateCareCommandHandler : IHandler<UpdateCareCommand, ResultViewModel<Guid>>
    {
        private readonly ICareRepository _careRepository;

        public UpdateCareCommandHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(UpdateCareCommand command)
        {
            var id = await _careRepository.GetCareByIdAsync(command.Id);
            await _careRepository.UpdateCareAsync(id);

            if (id == null)
                return ResultViewModel<Guid>.Failure(Error.NotFound("Atendimeto não encontrado!", "ClinicManagement.Application.Commands.Care.UpdateCare"));

            return ResultViewModel<Guid>.Success(command.Id);
        }
    }
}
