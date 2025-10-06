using ClinicManagement.Application.Common;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Service.DeleteService
{
    public class DeleteServiceCommandHandler : IHandler<DeleteServiceCommand, ResultViewModel<Guid>>
    {
        private readonly IServiceRepository _serviceRepository;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(DeleteServiceCommand command)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(command.Id);
            service.SetAsDelete();

            if (service  == null)
                return ResultViewModel<Guid>.Failure(Error.NotFound("Serviço não encontrado!", "ClinicManagement.Application.Commands.Service.DeleteService"));

            return ResultViewModel<Guid>.Success(command.Id);
        }
    }
}
