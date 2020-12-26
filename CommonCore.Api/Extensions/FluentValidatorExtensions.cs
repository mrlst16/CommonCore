using CommonCore.Models.Responses;
using FluentValidation.Results;
using System.Linq;

namespace CommonCore.Api.Extensions
{
    public static class FluentValidatorExtensions
    {
        public static ApiResponse<T> To400<T>(this ValidationResult validator)
            => new ApiResponse<T>()
            {
                FailureMessage = "Failed to validate request",
                Errors = validator.Errors.Select(x => new ErrorResponse()
                {
                    Message = x.ErrorMessage,
                    ErrorCode = x.ErrorCode
                })
                .ToList(),
                Sucess = false,
                Data = default(T)
            };
    }
}
