using ClinicManagement.Application.Common;
using ClinicManagement.Core.Repository;
using ClinicManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClinicManagement.Application.Commands.Speciality.DeleteSpeciality
{
    public class DeleteSpecialityCommandHandler : IHandler<DeleteSpecialityCommand, ResultViewModel<Guid>>
    {
        private readonly ISpecialtyRepository _specialityRepository;

        public DeleteSpecialityCommandHandler(ISpecialtyRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        public async Task<ResultViewModel<Guid>> HandlerAsync(DeleteSpecialityCommand command)
        {
            var id = await _specialityRepository.GetSpecialtyByIdAsync(command.Id);
            id.SetAsDeleted();

            if (id == null)
                return ResultViewModel<Guid>.Failure(Error.NotFound("Atendimeto não encontrado!", "ClinicManagement.Application.Commands.Care.DeleteCare"));

            return ResultViewModel<Guid>.Success(command.Id);
        }
    }
}
