using ClinicManagement.Core.Enum;

namespace ClinicManagement.Core.Entitys
{
    public class Care : BaseEntity
    {
        public Care(Guid idPaciente, Guid idService, Guid idMedic, AgreementEnum agreement, DateTime startService, DateTime finishService, TypeTreatmentEnum typeTreatment) : base()
        {
            IdPaciente = idPaciente;
            IdService = idService;
            IdMedic = idMedic;
            Agreement = agreement;
            StartService = startService;
            FinishService = finishService;
            TypeTreatment = typeTreatment;
            Confirmed = false;
            Anexos = [];
        }

        public Guid IdPaciente { get; private set; }
        public Patient Patient { get; set; }
        public Guid IdService { get; private set; }
        public Service Service { get; set; }
        public Guid IdMedic { get; private set; }
        public Medic Medic { get; set; }
        public AgreementEnum Agreement { get; private set; }
        public DateTime StartService { get; private set; }
        public DateTime FinishService { get; private set; }
        public TypeTreatmentEnum TypeTreatment { get; private set; }
        public bool Confirmed { get; private set; }
        public List<Anexo> Anexos { get; private set; }
        public bool IsDeleted { get; set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
        public void UpdateCare(AgreementEnum agreement, DateTime startService, DateTime finishService)
        {
            Agreement = agreement;
            StartService = startService;
            FinishService = finishService;
        }

        public void ConfirmedCare()
        {
            Confirmed = true;
        }

    }
}
