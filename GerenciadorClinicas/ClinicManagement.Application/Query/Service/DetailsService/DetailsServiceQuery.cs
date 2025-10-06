using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Query.Service.DetailsService
{
    public class DetailsServiceQuery
    {
        public DetailsServiceQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
