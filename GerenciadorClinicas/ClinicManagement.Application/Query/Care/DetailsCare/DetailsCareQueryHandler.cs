using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Application.DTO.ViewModel.Care;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Care.DetailsCare
{
    public class DetailsCareQueryHandler : IHandler<DetailsCareQuery, ResultViewModel<DetailsCareDto>>
    {
        private readonly ICareRepository _careRepository;

        public DetailsCareQueryHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }

        public async Task<ResultViewModel<DetailsCareDto>> HandlerAsync(DetailsCareQuery request)
        {
            var care = await _careRepository.GetCareByIdAsync(request.Id);
            if (care == null)
            {
                return ResultViewModel<DetailsCareDto>.Failure(Error.NotFound(
                    "ClinicManagement.Application.Queries.Care.DetailsCare",
                    $"Care with Id {request.Id} not found"));
            }
            var dto = new DetailsCareDto
            {
                IdPaciente = care.IdPaciente,
                PatientName = care.Patient.Name,
                IdService = care.IdService,
                ServiceName = care.Service.Name,
                IdMedic = care.IdMedic,
                MedicName = care.Medic.Name,
                Agreement = care.Agreement,
                StartService = care.StartService,
                FinishService = care.FinishService,
                TypeTreatment = care.TypeTreatment,
                Confirmed = care.Confirmed,
                Anexos = care.Anexos.Select(a => new AnexoDto
                {
                    NameFile = a.NameFile,
                    IdCare = a.IdCare,
                    Care = new CareDto
                    {
                        PatientId = care.IdPaciente,
                        ServiceId = care.IdService,
                        MedicId = care.IdMedic,
                        Agreement = care.Agreement,
                        StartService = care.StartService,
                        FinishService = care.FinishService,
                        TypeTreatment = care.TypeTreatment
                    },
                    TypeAnexo = a.TypeAnexo
                }).ToList()
            };

            return ResultViewModel<DetailsCareDto>.Success(dto);
        }
    }
}
