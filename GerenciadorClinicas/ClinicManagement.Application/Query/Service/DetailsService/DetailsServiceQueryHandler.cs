using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Application.DTO.ViewModel.Patient;
using ClinicManagement.Application.DTO.ViewModel.Service;
using ClinicManagement.Core.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Service.DetailsService
{
    public class DetailsServiceQueryHandler : IHandler<DetailsServiceQuery, ResultViewModel<DetailsServiceDto>>
    {
        private readonly IServiceRepository _serviceRepository;

        public DetailsServiceQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ResultViewModel<DetailsServiceDto>> HandlerAsync(DetailsServiceQuery query)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(query.Id);

            if (service == null)
            {
                return ResultViewModel<DetailsServiceDto>.Failure(
                    Error.NotFound(
                        "ClinicManagement.Application.Query.Service.DetailsService",
                        $"Serviço {query.Id} não encontrado"
                    )
                );
            }

            var dto = new DetailsServiceDto
            {
                Name = service.Name,
                Descripton = service.Descripton,
                Price = service.Price,
                Duration = service.Duration,
                Cares = new List<CareDto>()
               
            };

            return ResultViewModel<DetailsServiceDto>.Success(dto);
        }
    }
}