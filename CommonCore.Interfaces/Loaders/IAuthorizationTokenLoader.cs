using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.Loaders
{
    public interface IAuthorizationTokenLoader
    {
        Task<IResponse<string>> GetToken(PasswordRecord record);
    }
}
