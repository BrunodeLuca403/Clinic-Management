using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Application.DTO.ViewModel.Medic;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Medic.DetailsMedic
{
    public class DetailsMedicQueryHandler : IHandler<DetailsMedicQuery, ResultViewModel<DetailsMedicDto>>
    {
        private readonly IMedicRepository _medicRepository;

        public DetailsMedicQueryHandler(IMedicRepository medicRepository)
        {
            _medicRepository = medicRepository;
        }

        public async Task<ResultViewModel<DetailsMedicDto>> HandlerAsync(DetailsMedicQuery request)
        {
            var medic = await _medicRepository.GetMedicByIdAsync(request.Id);

            if (medic == null)
            {
                return ResultViewModel<DetailsMedicDto>.Failure(
                    Error.NotFound(
                        "ClinicManagement.Application.Queries.Medic.DetailsMedic",
                        $"Médico com Id {request.Id} não encontrado"
                    )
                );
            }

            var dto = new DetailsMedicDto
            {
                Id = medic.Id,
                Name = medic.Name,
                LastName = medic.LastName,
                PhoneNumber = medic.PhoneNumber,
                Email = medic.Email,
                CRM = medic.CRM,
                Uf = medic.Uf,
                Address = new AddressDto
                {
                    Street = medic.Address.Street,
                    Number = medic.Address.Number,
                    Complement = medic.Address.Complement,
                    City = medic.Address.City,
                    State = medic.Address.State,
                    ZipCode = medic.Address.ZipCode
                }
            };

            return ResultViewModel<DetailsMedicDto>.Success(dto);
        }
    }
}
