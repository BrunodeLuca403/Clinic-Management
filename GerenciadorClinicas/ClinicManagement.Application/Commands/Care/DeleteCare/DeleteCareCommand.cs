using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Care.DeleteCare
{
    public class DeleteCareCommand
    {
        public DeleteCareCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public void SetAsDeleted()
        {
            IsDeleted = true;
        }

    }

    
}
