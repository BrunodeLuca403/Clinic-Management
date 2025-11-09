using ClinicManagement.API.Context;
using ClinicManagement.Application.Commands.Patient.RegistePatient;
using ClinicManagement.Infrastructure.Repository;
using ClinicManagement.Tests.Integration.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Tests.Integration.Application
{
    public class RegisterPatientIntegrationTests
    {
        [Fact]
        public async Task DeveCadastrarPacienteNoBancoComDadosValidos()
        {
            var options = new DbContextOptionsBuilder<ClinicDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            await using var context = new ClinicDbContext(options);
            var repository = new PatientRepository(context);
            var handler = new RegisterPatientCommandHandler(repository);
            var command = PatientTests.CreateFakeRegisterPatientCommand();

            var result = await handler.HandlerAsync(command);

            Assert.True(result.IsSuccess);
            var patientInDb = await context.Patients.FirstOrDefaultAsync(p => p.CPF == command.CPF);
            Assert.NotNull(patientInDb);
        }
    }
}
