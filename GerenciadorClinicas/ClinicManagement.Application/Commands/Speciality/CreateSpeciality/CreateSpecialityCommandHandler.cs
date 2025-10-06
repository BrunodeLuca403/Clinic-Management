using ClinicManagement.Application.Common;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Speciality.CreateSpeciality
{
    public class CreateSpecialityCommandHandler : IHandler<CreateSpecialityCommand, ResultViewModel<Guid>>
    {
        private readonly ISpecialtyRepository _specialtyRepository;

        public CreateSpecialityCommandHandler(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(CreateSpecialityCommand command)
        {
            try
            {
                var specialty = new Specialty(command.CodeSpecialty, command.NameSpeacialty);
                return ResultViewModel<Guid>.Success(specialty.Id);
            }
            catch (Exception ex)
            {
                return ResultViewModel<Guid>.Failure(Error.Failure("ClinicManagement.Application.Commands.Care.CreateCare", ex.Message));
            }
        }
    }
}
