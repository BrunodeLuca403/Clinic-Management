using ClinicManagement.Application.DTO.InputModel;
using ClinicManagement.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTO.ViewModel.Speciality
{
    public class DetailsSpecialityDto
    {
        public DetailsSpecialityDto(Guid id, string codeSpecialty, string nameSpeacialty)
        {
            Id = id;
            CodeSpecialty = codeSpecialty;
            NameSpeacialty = nameSpeacialty;
        }

        public Guid Id { get; set; }
        public string CodeSpecialty { get;  set; }
        public string NameSpeacialty { get;  set; }
        public List<MedicSpecialtyDto> MedicSpecialties { get;  set; }
    }
}
