using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.ViewModel.Patient;
using ClinicManagement.Application.DTO.ViewModel.Service;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Service.ListService
{
    public class ListServiceQueryHandler : IHandler<ListServiceQuery, ResultViewModel<List<ListServiceDto>>>
    {
        private readonly IServiceRepository _serviceRepository;

        public ListServiceQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ResultViewModel<List<ListServiceDto>>> HandlerAsync(ListServiceQuery request)
        {
            var service = await _serviceRepository.GetAllServicesAsync();
            var ServiceDto = service.Select(c => new ListServiceDto
            {
                Name = c.Name,
                Duration = c.Duration
            }).ToList();
            return ResultViewModel<List<ListServiceDto>>.Success(ServiceDto);
        }
    }
}
