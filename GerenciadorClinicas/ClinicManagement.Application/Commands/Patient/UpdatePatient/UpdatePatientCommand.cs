using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Patient.UpdatePatient
{
    public class UpdatePatientCommand
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public string Bithdate { get; set; }
        public string Fone { get;  set; }
        public string Email { get;  set; }
        public TypeBlood TypeBlood { get;  set; }
        public decimal HeightPatient { get;  set; }
        public string Weight { get;  set; }
        public AddressDto Address { get; set; }
    }
}
