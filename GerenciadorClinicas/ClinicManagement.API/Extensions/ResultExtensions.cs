using ClinicManagement.Application;
using ClinicManagement.Application.Common;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Enum;
using System.Runtime.CompilerServices;

namespace ClinicManagement.API.Extensions
{
    public static class ResultExtensions
    {
        public static IResult MapResult<T>(this IResultExtensions resultExtensions, ResultViewModel<T> result)
        {
            if (result.IsSuccess)
                return Results.Ok(result.Value);

            return GetErrorResult(result.Error);
         
        }

        internal static IResult GetErrorResult(Error error)
        {
            return error.Type switch
            {
                ErrorTypeEnum.Validation => Results.BadRequest(error),
                ErrorTypeEnum.Conflict => Results.Conflict(error),
                ErrorTypeEnum.NotFound => Results.NotFound(error),
                ErrorTypeEnum.Unauthorized => Results.Unauthorized(),
                _ => Results.Problem(
                    statusCode: 500,
                    title: "Server Faliure",
                    type: Enum.GetName(typeof(ErrorTypeEnum), error.Type),
                    extensions: new Dictionary<string, object?>
                    {
                        { "errors", new [] { error } },
                    }   
                ),
            };
        }
    }
}
