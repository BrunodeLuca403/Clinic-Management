using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Common
{
    public interface IHandler<TRequest, TResponse>
    {
        Task<TResponse> HandlerAsync(TRequest request);

    }
}
