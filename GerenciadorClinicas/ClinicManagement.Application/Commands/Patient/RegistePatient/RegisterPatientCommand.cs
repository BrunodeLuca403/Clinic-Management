using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Enum;
using ClinicManagement.Core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Patient.RegistePatient
{
    public class RegisterPatientCommand
    {
        public RegisterPatientCommand(string name, string lastName, string bithdate, string fone, string email, string cPF, TypeBlood typeBlood, decimal heightPatient, string weight, AddressDto address)
        {
            Name = name;
            LastName = lastName;
            Bithdate = bithdate;
            Fone = fone;
            Email = email;
            CPF = cPF;
            TypeBlood = typeBlood;
            HeightPatient = heightPatient;
            Weight = weight;
            Address = address;
        }

        public string Name { get;  set; }
        public string LastName { get;  set; }
        public string Bithdate { get; set; }
        public string Fone { get;  set; }
        public string Email { get;  set; }
        public string CPF { get;  set; }
        public TypeBlood TypeBlood { get;  set; }
        public decimal HeightPatient { get;  set; }
        public string Weight { get;  set; }
        public AddressDto Address { get;  set; }
    }
}
