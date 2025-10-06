using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Caching
{
    public interface ICachingService
    {
        Task setAsync(string key, string value);
        Task<string> getAsync(string key);
    }
}
