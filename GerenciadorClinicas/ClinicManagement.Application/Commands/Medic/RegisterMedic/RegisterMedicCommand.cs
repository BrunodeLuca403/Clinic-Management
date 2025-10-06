using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Enum;
using ClinicManagement.Core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Medic.RegisterMedic
{
    public class RegisterMedicCommand 
    {
        public RegisterMedicCommand(string name, string lastName, DateTime bithdate, string phoneNumber, string email, string cPF, TypeBlood typeBlood, string cRM, int advice, string uf, AddressDto address)
        {
            Name = name;
            LastName = lastName;
            Bithdate = bithdate;
            PhoneNumber = phoneNumber;
            Email = email;
            CPF = cPF;
            TypeBlood = typeBlood;
            CRM = cRM;
            Advice = advice;
            Uf = uf;
            Address = address;
            MedicSpecialties = [];
            Cares = [];
        }

        public string Name { get;  set; }
        public string LastName { get;  set; }
        public DateTime Bithdate { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Email { get;  set; }
        public string CPF { get;  set; }
        public TypeBlood TypeBlood { get;  set; }
        public string CRM { get;  set; }
        public int Advice { get;  set; }
        public string Uf { get;  set; }
        public AddressDto Address { get; set; }
        public List<MedicSpecialtyDto> MedicSpecialties { get;  set; }
        public List<CareDto> Cares { get;  set; }
    }
}
