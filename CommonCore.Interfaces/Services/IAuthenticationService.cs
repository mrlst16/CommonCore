using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<IResponse> SetupPassword(PasswordRequest request);
        Task<IResponse<string>> Authenticate(PasswordRequest request);
    }
}
