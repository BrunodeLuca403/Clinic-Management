using ClinicManagement.Core.Enum;

namespace ClinicManagement.Application.DTO.InputModel
{
    public class CareDto
    {
        public Guid PatientId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid MedicId { get; set; }
        public AgreementEnum Agreement { get; set; }
        public DateTime StartService { get; set; }
        public DateTime FinishService { get; set; }
        public TypeTreatmentEnum TypeTreatment { get; set; }
    }

}
