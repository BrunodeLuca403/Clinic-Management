using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.ViewModel.Care;
using ClinicManagement.Application.DTO.ViewModel.Medic;
using ClinicManagement.Core.Repository;
using ClinicManagement.Infrastructure.Caching;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Medic.ListMedic
{
    public class ListMedicQueryHandler : IHandler<ListMedicQuery, ResultViewModel<List<ListMedicDto>>>
    {
        private readonly IMedicRepository _medicRepository;
        private readonly ICachingService _cachingService;
        public ListMedicQueryHandler(IMedicRepository medicRepository, ICachingService cachingService)
        {
            _medicRepository = medicRepository;
            _cachingService = cachingService;
        }

        public async Task<ResultViewModel<List<ListMedicDto>>> HandlerAsync(ListMedicQuery request)
        {
            var cacheKey = $"ListMedic_{JsonConvert.SerializeObject(request)}";

            var cachedData = await _cachingService.getAsync(cacheKey);

            if (!string.IsNullOrWhiteSpace(cachedData))
            {
                var cachedList = JsonConvert.DeserializeObject<List<ListMedicDto>>(cachedData);

                return ResultViewModel<List<ListMedicDto>>.Success(cachedList);
            }

            var medics = await _medicRepository.GetAllMedicsAsync();

            if(medics == null)
            {
                return ResultViewModel<List<ListMedicDto>>.Failure(
                    Error.NotFound(
                        "ClinicManagement.Application.Query.Medic.ListMedic",
                        "Nenhum médico encontrado"
                    )
                );
            }


            var MedicDtos = medics.Select(c => new ListMedicDto
            {
                Name = c.Name,
                CRM = c.CRM,
                Advice = c.Advice,
                Uf = c.Uf,
                Id = c.Id

            }).ToList();

            await _cachingService.setAsync(cacheKey, JsonConvert.SerializeObject(MedicDtos));


            return ResultViewModel<List<ListMedicDto>>.Success(MedicDtos);
        }
    }
}
