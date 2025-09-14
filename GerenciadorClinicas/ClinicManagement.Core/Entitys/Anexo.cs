using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Enum;

namespace ClinicManagement.Core.Entitys
{
       public class Anexo : BaseEntity
    {
        public Anexo(string nameFile, Guid idCare, TypeAnexoEnum typeAnexo) : base()
        {
            NameFile = nameFile;
            IdCare = idCare;
            TypeAnexo = typeAnexo;
        }

        public string NameFile { get; set; }
        public Guid IdCare { get; set; }
        public Care Care { get; set; }
        public TypeAnexoEnum TypeAnexo { get; private set; }
    }
}
