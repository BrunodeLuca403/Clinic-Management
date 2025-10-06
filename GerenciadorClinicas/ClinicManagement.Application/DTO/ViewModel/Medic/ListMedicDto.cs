using ClinicManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTO.ViewModel.Medic
{
    public class ListMedicDto
    {


        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string CRM { get;  set; }
        public int Advice { get;  set; }
        public string Uf { get;  set; }
    }
}
