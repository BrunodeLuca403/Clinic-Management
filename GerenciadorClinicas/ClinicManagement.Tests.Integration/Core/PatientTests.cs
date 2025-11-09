using Bogus;
using Bogus.Extensions.Brazil;
using ClinicManagement.Application.Commands.Patient.RegistePatient;
using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Tests.Integration.Core
{
    public class PatientTests
    {
        private static readonly Faker _faker = new("pt_BR");

        private static readonly Faker<RegisterPatientCommand> _registerPatientCommand = new Faker<RegisterPatientCommand>("pt_BR")
            .CustomInstantiator(f => new RegisterPatientCommand(
                name: f.Name.FirstName(),
                lastName: f.Name.LastName(),
                bithdate: f.Date.Past(30, DateTime.Now.AddYears(-18)).ToString("yyyy-MM-dd"), 
                fone: f.Phone.PhoneNumber("(##) #####-####"),
                email: f.Internet.Email(),
                cPF: f.Person.Cpf(),
                typeBlood: f.PickRandom<TypeBlood>(),
                heightPatient: Math.Round(f.Random.Decimal(1.50m, 2.00m), 2), 
                weight: f.Random.Int(50, 110).ToString(),
                address: new AddressDto
                {
                    Street = f.Address.StreetAddress(),
                    City = f.Address.City(),
                    ZipCode = f.Address.ZipCode(),
                    State = f.Address.StateAbbr()
                }
            ));

        public static RegisterPatientCommand CreateFakeRegisterPatientCommand()
        {
            return _registerPatientCommand.Generate();
        }
    }
}
