using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Care.CreateCare
{
    public class CreateCareCommand 
    {
        public CreateCareCommand(Guid idPaciente, Guid idService, Guid idMedic, AgreementEnum agreement, DateTime startService, DateTime finishService, TypeTreatmentEnum typeTreatment)
        {
            IdPaciente = idPaciente;
            IdService = idService;
            IdMedic = idMedic;
            Agreement = agreement;
            StartService = startService;
            FinishService = finishService;
            TypeTreatment = typeTreatment;
            Anexos = [];
        }

        public Guid IdPaciente { get; set; }
        public Guid IdService { get; set; }
        public Guid IdMedic { get; set; }
        public AgreementEnum Agreement { get; set; }
        public DateTime StartService { get; set; }
        public DateTime FinishService { get; set; }
        public TypeTreatmentEnum TypeTreatment { get; set; }
        public List<AnexoDto> Anexos { get; private set; }

    }

}
