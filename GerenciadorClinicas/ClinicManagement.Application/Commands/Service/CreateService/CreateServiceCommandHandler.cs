using ClinicManagement.Application.Common;
using ClinicManagement.Core.Repository;
using ClinicManagement.Infrastructure.Service;
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
        private readonly IAService _service;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository, IAService service)
        {
            _serviceRepository = serviceRepository;
            _service = service;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(CreateServiceCommand command)
        {
            try
            {

                var summary = command.Descripton; 
                var prompt = "Com base nisso, realize a analise do procedimento e escreva um breve descrição sobre esse procedimento.";
                var generatedDescription = await _service.Complete(prompt, summary);
                
                var service = new Core.Entitys.Service(command.Name, generatedDescription, command.Price, command.Duration);
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
