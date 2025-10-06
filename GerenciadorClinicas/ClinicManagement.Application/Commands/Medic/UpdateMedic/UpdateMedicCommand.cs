using ClinicManagement.Application.DTO.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Medic.UpdateMedic
{
    public class UpdateMedicCommand
    {
        public UpdateMedicCommand(string name, string lastName, string phoneNumber, string email, string crm, string uf, AddressDto address, Guid id)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Crm = crm;
            Uf = uf;
            Address = address;
            Id = id;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Crm { get; set; }
        public string Uf { get; set; }
        public AddressDto Address { get; set; }
    }
}
