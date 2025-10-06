using ClinicManagement.Application.Common;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Service.CreateService
{
    public class CreateServiceCommandHandler : IHandler<CreateServiceCommand, ResultViewModel<Guid>>
    {
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(CreateServiceCommand command)
        {
            try
            {
                var service = new Core.Entitys.Service(command.Name, command.Descripton, command.Price, command.Duration);
                await _serviceRepository.AddServiceAsync(service);
                return ResultViewModel<Guid>.Success(service.Id);
            }
            catch (Exception ex)
            {
                return ResultViewModel<Guid>.Failure(Error.Failure("ClinicManagement.Application.Commands.Service.CreateService", ex.Message));
            }
        }
    }
}
