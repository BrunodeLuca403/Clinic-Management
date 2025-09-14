using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTO.InputModel.Care.CreateCare
{
    public class CreateCareInputModel
    {
        public Guid IdPaciente { get;  set; }
        public string Patient { get; set; }
        public Guid IdService { get;  set; }
        public string Service { get; set; }
        public Guid IdMedic { get;  set; }
        public string Medic { get; set; }
        public string Agreement { get;  set; }
        public DateTime StartService { get;  set; }
        public DateTime FinishService { get;  set; }
        public string TypeTreatment { get;  set; }
        public bool Confirmed { get;  set; }
        public List<string> Anexos { get;  set; }
        public bool IsDeleted { get; set; }
    }
}
