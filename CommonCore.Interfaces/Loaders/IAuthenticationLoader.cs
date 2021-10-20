using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.Loaders
{
    public interface IAuthenticationLoader
    {
        Task<IResponse> SetupPassword(PasswordRequest request);
        Task<IResponse<PasswordRecord>> Authenticate(PasswordRequest request);

    }
}
