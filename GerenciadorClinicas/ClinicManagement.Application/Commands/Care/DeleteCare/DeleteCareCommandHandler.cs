using ClinicManagement.Application.Common;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Care.DeleteCare
{
    public class DeleteCareCommandHandler : IHandler<DeleteCareCommand, ResultViewModel<Guid>>
    {
        private readonly ICareRepository _careRepository;

        public DeleteCareCommandHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(DeleteCareCommand command)
        {
            var id = await _careRepository.GetCareByIdAsync(command.Id);
            command.SetAsDeleted();

            if (id == null)
                return ResultViewModel<Guid>.Failure(Error.NotFound("Atendimeto não encontrado!", "ClinicManagement.Application.Commands.Care.DeleteCare"));

            return ResultViewModel<Guid>.Success(command.Id);
        }
    }
}
