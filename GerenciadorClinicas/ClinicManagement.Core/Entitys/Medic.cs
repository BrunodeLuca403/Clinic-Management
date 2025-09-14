using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Enum;
using ClinicManagement.Core.ValuesObjects;
using System.Net;

namespace ClinicManagement.Core.Entitys
{
    public class Medic : BaseEntity
    {
        public Medic(string name, string lastName, DateTime bithdate, string phoneNumber, string email, string cPF, TypeBlood typeBlood, string cRM, int advice, string uf) : base()
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
            MedicSpecialties = [];
            Cares = [];
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime Bithdate { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public TypeBlood TypeBlood { get; private set; }
        public string CRM { get; private set; }
        public int Advice { get; private set; }
        public string Uf { get; private set; }
        public Address Address { get; set; }
        public List<MedicSpecialty> MedicSpecialties { get; private set; }
        public List<Care> Cares { get; private set; }
        public bool IsDeleted { get; set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }

        public void UpdateMedic(string name, string lastName, string phoneNumber, string email, string cRM, string uF, Address address)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            CRM = cRM;
            Uf = uF;
            Address = address;
        }
    }
}
