using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Service
{
    public interface IAService
    {
        Task<string> Complete(string systemPrompt, string userPrompt);
    }
}
