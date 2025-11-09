using ClinicManagement.Application.Commands.Medic.UpdateMedic;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Enum;
using ClinicManagement.Core.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Tests.Unit.Application
{
    public class UpdateMedicCommandTests
    {
        private readonly UpdateMedicCommandHandler _updateHandler;
        private readonly Mock<IMedicRepository> _repositoryMock;

        public UpdateMedicCommandTests()
        {
            _repositoryMock = new Mock<IMedicRepository>();
            _updateHandler = new UpdateMedicCommandHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task RealizarUpdateComDadosValidos()
        {
            var command = new UpdateMedicCommand(
                  "João",
                  "Silva",
                  "11999999999",
                  "joao@test.com",
                  "CRM123",
                  "SP",
                  new AddressDto
                  {
                      Street = "Rua X",
                      Number = "123",
                      Complement = "",
                      Neighborhood = "Bairro",
                      City = "Cidade",
                      State = "SP",
                      ZipCode = "00000-000"
                  },
                  Guid.NewGuid()
              );

            _repositoryMock.Setup(r => r.GetMedicByIdAsync(command.Id))
               .ReturnsAsync(new Medic(
                   "João", "Silva", DateTime.Now, "11999999999", "joao@test.com",
                   "00011122233", TypeBlood.APositivo, "CRM123", 0, "SP"
               ));

            _repositoryMock.Setup(r => r.UpdateMedicAsync(It.IsAny<Medic>()))
                    .ReturnsAsync((Medic m) => m);

            var result = await _updateHandler.HandlerAsync(command);

            Assert.True(result.IsSuccess);
            Assert.Equal(command.Id, result.Value);

            _repositoryMock.Verify(r => r.UpdateMedicAsync(It.IsAny<Medic>()), Times.Once);
        }

    }
}
