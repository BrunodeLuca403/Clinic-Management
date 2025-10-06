using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTO.ViewModel.Care
{
    public class DetailsCareDto
    {
        public Guid IdPaciente { get;  set; }
        public string PatientName { get; set; }
        public Guid IdService { get;  set; }
        public string ServiceName { get; set; }
        public Guid IdMedic { get;  set; }
        public string MedicName { get; set; }
        public AgreementEnum Agreement { get;  set; }
        public DateTime StartService { get;  set; }
        public DateTime FinishService { get;  set; }
        public TypeTreatmentEnum TypeTreatment { get;  set; }
        public bool Confirmed { get;  set; }
        public List<AnexoDto> Anexos { get;  set; }
    }
}
