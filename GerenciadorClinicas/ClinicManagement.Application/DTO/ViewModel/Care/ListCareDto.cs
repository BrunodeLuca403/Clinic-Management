using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTO.ViewModel.Care
{
    public class ListCareDto
    {
        public Guid IdPaciente { get;  set; }
        public string PatientName { get; set; }
        public Guid IdService { get;  set; }
        public string ServiceName { get; set; }
        public Guid IdMedic { get;  set; }
        public string MedicName { get; set; }
    }
}
