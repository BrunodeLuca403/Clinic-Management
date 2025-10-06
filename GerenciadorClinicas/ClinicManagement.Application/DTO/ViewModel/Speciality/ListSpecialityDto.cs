using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTO.ViewModel.Speciality
{
    public class ListSpecialityDto
    {
        public Guid Id { get; set; }
        public string CodeSpecialty { get; set; }
        public string NameSpeacialty { get; set; }
    }
}
