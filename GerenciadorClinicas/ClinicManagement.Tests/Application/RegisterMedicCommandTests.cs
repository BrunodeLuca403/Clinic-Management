using ClinicManagement.Application.Commands.Medic.RegisterMedic;
using ClinicManagement.Application.Commands.Medic.UpdateMedic;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Enum;
using ClinicManagement.Core.Repository;
using ClinicManagement.Tests.Core;
using ClinicManagement.Tests.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClinicManagement.Tests.Unit.Application
{
    public class RegisterMedicCommandTests
    {
        private readonly Mock<IMedicRepository> _repositoryMock;
        private readonly RegisterMedicCommandHandler _handler;
        private readonly UpdateMedicCommandHandler _updateHandler;

        public RegisterMedicCommandTests()
        {
            _repositoryMock = new Mock<IMedicRepository>();
            _handler = new RegisterMedicCommandHandler(_repositoryMock.Object);
            _updateHandler = new UpdateMedicCommandHandler(_repositoryMock.Object);

        }

        [Fact]
        public async Task DeveCadastrarMedicoComDadosValidos()
        {
            var command = MedicTests.CreateFakeRegisterMedicCommand();

            _repositoryMock.Setup(r => r.ExistsByCrmAsync(command.CRM))
                .ReturnsAsync(true);

            var result = await _handler.HandlerAsync(command);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Error);
            Assert.Contains("Já existe um médico cadastrado", result.Error.Description);

            _repositoryMock.Verify(r => r.AddMedicAsync(It.IsAny<Medic>()), Times.Never);
        }

       
    }
}