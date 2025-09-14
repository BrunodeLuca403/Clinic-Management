using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Common
{
    public interface IMediator
    {
        Task<TResponse> DispatchAsync<TRequest, TResponse>(TRequest request);

    }
}
