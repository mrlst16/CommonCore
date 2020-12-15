using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.Loaders
{
    public interface IAuthenticationLoader
    {
        Task<IResponse> SetupPassword(PasswordRequest request);
        Task<IResponse<PasswordRecord>> Authenticate(PasswordRequest request);

    }
}
