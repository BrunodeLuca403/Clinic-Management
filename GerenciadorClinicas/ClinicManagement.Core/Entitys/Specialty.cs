namespace ClinicManagement.Core.Entitys
{
    public class Specialty : BaseEntity
    {
        public Specialty(string codeSpecialty, string nameSpeacialty) : base()
        {
            CodeSpecialty = codeSpecialty;
            NameSpeacialty = nameSpeacialty;
            MedicSpecialties = [];
        }

        public string CodeSpecialty { get; private set; }
        public string NameSpeacialty { get; private set; }
        public List<MedicSpecialty> MedicSpecialties { get; private set; }
        public bool IsDeleted { get; set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
