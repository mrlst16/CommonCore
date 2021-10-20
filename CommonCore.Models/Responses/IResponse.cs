using System.Collections.Generic;

namespace CommonCore.Models.Responses
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; }
    }

    public interface IResponse
    {
        bool Sucess { get; }
        IList<ErrorResponse> Errors { get; set; }
    }
}
