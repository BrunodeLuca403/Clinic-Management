using ClinicManagement.Application.Common;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Medic.RegisterMedic
{
    public class RegisterMedicCommandHandler : IHandler<RegisterMedicCommand, ResultViewModel<Guid>>
    {
        private readonly IMedicRepository _medicRrepository;

        public RegisterMedicCommandHandler(IMedicRepository medicRrepository)
        {
            _medicRrepository = medicRrepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(RegisterMedicCommand request)
        {
            try
            {
                var findMedic = await _medicRrepository.ExistsByCrmAsync(request.CRM);
                
                if(findMedic == true){  
                    return ResultViewModel<Guid>.Failure(
                        Error.Conflict(
                            "ClinicManagement.Application.Commands.Medic.CreateMedic",
                            $"Já existe um médico cadastrado com o CRM {request.CRM}."
                        )
                    );
                }

                var medic = new Core.Entitys.Medic(request.Name, request.LastName, request.Bithdate, request.PhoneNumber, request.Email, request.CPF, request.TypeBlood, request.CRM, request.Advice, request.Uf);
                await _medicRrepository.AddMedicAsync(medic);
                return ResultViewModel<Guid>.Success(medic.Id);
            }
            catch(Exception ex)
            {
                return ResultViewModel<Guid>.Failure(Error.Failure("ClinicManagement.Application.Commands.Medic.CreateMedic", ex.Message));
            }
           
        }
    }
}
