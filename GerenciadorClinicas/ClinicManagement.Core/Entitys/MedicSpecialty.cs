using ClinicManagement.Core.Entitys;

namespace ClinicManagement.Core.Entitys
{
    public class MedicSpecialty : BaseEntity
    {

        public MedicSpecialty(Guid medicId, Guid specialtyId) : base()
        {
            MedicId = medicId;
            SpecialtyId = specialtyId;
        }

        public Guid MedicId { get; private set; }
        public Medic Medic { get; private set; }

        public Guid SpecialtyId { get; private set; }
        public Specialty Specialty { get; private set; }
    }
}
