using ClinicManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Entitys
{
    public record Error
    {
        public static Error None => new(string.Empty, string.Empty, ErrorType.Failure);

        private Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description ?? string.Empty;
            type = type;
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public ErrorType Type { get; set; }

        public static Error Validation(string code, string description) => new(code, description, ErrorType.Validation);
        public static Error NotFound(string code, string description) => new(code, description, ErrorType.NotFound);
        public static Error Conflict(string code, string description) => new(code, description, ErrorType.Conflict);
        public static Error Unauthorized(string code, string description) => new(code, description, ErrorType.Unauthorized);
        public static Error Failure(string code, string description) => new(code, description, ErrorType.Failure);
    }


}
