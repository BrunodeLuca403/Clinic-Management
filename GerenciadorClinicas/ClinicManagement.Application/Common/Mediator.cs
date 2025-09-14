using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Common
{
    public class Mediator : IMediator
    {
        readonly IServiceScopeFactory _serviceScopeFactory;

        public Mediator(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<TResponse> DispatchAsync<TRequest, TResponse>(TRequest request)
        {
            var scope = _serviceScopeFactory.CreateScope();
            var handler = scope.ServiceProvider.GetService<IHandler<TRequest, TResponse>>();
            return await handler.HandlerAsync(request);
        }
    }
}
