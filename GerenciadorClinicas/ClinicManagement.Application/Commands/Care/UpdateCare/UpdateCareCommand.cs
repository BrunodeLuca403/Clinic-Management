using ClinicManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Care.UpdateCare
{
    public class UpdateCareCommand
    {
        public UpdateCareCommand(AgreementEnum agreement, DateTime startService, DateTime finishService, TypeTreatmentEnum typeTreatment, Guid id)
        {
            Agreement = agreement;
            StartService = startService;
            FinishService = finishService;
            TypeTreatment = typeTreatment;
            Id = id;
        }
        public Guid Id { get; set; }
        public AgreementEnum Agreement { get;  set; }
        public DateTime StartService { get;  set; }
        public DateTime FinishService { get;  set; }
        public TypeTreatmentEnum TypeTreatment { get;  set; }
    }
}
