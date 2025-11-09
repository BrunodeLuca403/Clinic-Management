using ClinicManagement.API.Context;
using ClinicManagement.Application.Commands.Patient.RegistePatient;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using ClinicManagement.Infrastructure.Repository;
using ClinicManagement.Tests.Unit.Core;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Tests.Unit.Application
{
    public class RegisterPatientCommandHandlerTests
    {
        RegisterPatientCommandHandler _handler;
        private readonly Mock<IPatientRepository> _repositoryMock;

        public RegisterPatientCommandHandlerTests()
        {
            _repositoryMock = new Mock<IPatientRepository>();
            _handler = new RegisterPatientCommandHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task DeveCadastrarPacienteComDadosValidos()
        {
            var command = PatientTests.CreateFakeRegisterPatientCommand();

            _repositoryMock.Setup(r => r.GetPatientByIdAsync(command.CPF))
                .ReturnsAsync((Patient)null);


            _repositoryMock.Setup(r => r.AddPatientAsync(It.IsAny<Patient>()))
                         .ReturnsAsync((Patient p) => p);

            var result = await _handler.HandlerAsync(command);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Error);

            _repositoryMock.Verify(r => r.AddPatientAsync(It.IsAny<Patient>()), Times.Once);

            _repositoryMock.Verify(r => r.GetPatientByIdAsync(command.CPF), Times.Once);
        }
    }
}
