using ClinicManagement.Core.Enum;

namespace ClinicManagement.Application.DTO.InputModel
{
    public class  AnexoDto
    {
        public CareDto Care { get; set; }
        public Guid IdCare { get; set; }
        public string NameFile { get; set; }
        public TypeAnexoEnum TypeAnexo { get;  set; }
    }

}
