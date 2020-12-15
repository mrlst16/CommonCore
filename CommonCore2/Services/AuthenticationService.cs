using CommonCore.Interfaces.Loaders;
using CommonCore.Interfaces.Services;
using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using System.Threading.Tasks;

namespace CommonCore2.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationLoader _authenticationLoader;
        private readonly IAuthorizationTokenLoader _tokenLoader;

        public AuthenticationService(
            IAuthenticationLoader authenticationLoader,
            IAuthorizationTokenLoader tokenLoader
            )
        {
            _authenticationLoader = authenticationLoader;
            _tokenLoader = tokenLoader;
        }

        public async Task<IResponse<string>> Authenticate(PasswordRequest request)
        {
            var authenticationResponse = await _authenticationLoader.Authenticate(request);
            if (!authenticationResponse.Sucess) return new MethodResponse<string>()
            {
                Sucess = false,
                Data = null,
                Errors = authenticationResponse.Errors
            };
            return await _tokenLoader.GetToken(authenticationResponse.Data);
        }

        public async Task<IResponse> SetupPassword(PasswordRequest request)
            => await _authenticationLoader.SetupPassword(request);
    }
}
