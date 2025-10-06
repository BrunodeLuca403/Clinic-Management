using ClinicManagement.Core.Enum;
using ClinicManagement.Core.ValuesObjects;
using System.Net;

namespace ClinicManagement.Core.Entitys
{
    public class Patient : BaseEntity
    {
        public Patient(string name, string lastName, string bithdate, string fone, string email, string cPF, TypeBlood typeBlood, decimal heightPatient, string weight)
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
            Cares = [];
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Bithdate { get; set; }
        public string Fone { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public TypeBlood TypeBlood { get; private set; }
        public decimal HeightPatient { get; private set; }
        public string Weight { get; private set; }
        public List<Care> Cares { get; private set; }
        public Address Address { get; private set; }
        public bool IsDeleted { get; set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
        public void UpdatePatient(string email, TypeBlood typeBlood, decimal heightPatient, string weight, Address address, string phone)
        {
            Email = email;
            TypeBlood = typeBlood;
            HeightPatient = heightPatient;
            Weight = weight;
            Address = address;
            Fone = phone;
        }
    }   
}
