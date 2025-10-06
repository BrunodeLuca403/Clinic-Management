using ClinicManagement.Application.Common;
using System.Net;
using System.Text.Json;

namespace ClinicManagement.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado. TraceId={TraceId}", context.TraceIdentifier);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var error = Error.Failure(
                        code: context.Response.StatusCode.ToString(),
                        description: "Ocorreu um erro interno no servidor.",
                        details: $"CorrelationId: {context.TraceIdentifier}"
                    );

                var response = ResultViewModel<object>.Failure(error);


                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
