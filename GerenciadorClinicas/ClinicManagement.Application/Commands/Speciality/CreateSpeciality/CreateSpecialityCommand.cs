using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Speciality.CreateSpeciality
{
    public class CreateSpecialityCommand
    {

        public string CodeSpecialty { get; set; }
        public string NameSpeacialty { get; set; }
        public List<MedicSpecialtyDto> MedicSpecialties { get; set; }
    }
}
