using Bogus;
using Bogus.Extensions.Brazil;
using ClinicManagement.Application.Commands.Medic.RegisterMedic;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Tests.Integration.Core
{
    public class MedicTests
    {
        private static readonly Faker _faker = new("pt_BR");

        private static readonly Faker<RegisterMedicCommand> _registerMedicCommand = new Faker<RegisterMedicCommand>()
            .CustomInstantiator(f => new RegisterMedicCommand(
                f.Name.FirstName(),
                f.Name.LastName(),
                f.Date.Past(30, DateTime.Now.AddYears(-25)),
                f.Phone.PhoneNumber(),
                f.Internet.Email(),
                f.Person.Cpf(false),
                f.PickRandom<TypeBlood>(),
                f.Random.AlphaNumeric(6).ToUpper(),
                f.Random.Int(1000, 9999),
                f.Address.StateAbbr(),
                new AddressDto
                {
                    Street = f.Address.StreetAddress(),
                    City = f.Address.City(),
                    ZipCode = f.Address.ZipCode(),
                    State = f.Address.StateAbbr()
                }
            ));

        public static RegisterMedicCommand CreateFakeRegisterMedicCommand()
        {
            return _registerMedicCommand.Generate();
        }


    }
}
