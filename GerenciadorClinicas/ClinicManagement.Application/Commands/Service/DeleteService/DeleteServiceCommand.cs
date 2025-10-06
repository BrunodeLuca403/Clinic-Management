using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.Service.DeleteService
{
    public class DeleteServiceCommand
    {
        public DeleteServiceCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
