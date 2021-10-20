using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CommonCore.Api.Handlers
{
    public class JWTAuthorizationHandler : AuthorizationHandler<JWTAuthorizationRequirement>
    {
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, JWTAuthorizationRequirement requirement)
        {
            if (string.IsNullOrWhiteSpace(context?.User?.Identity?.Name))
            {
                context.Fail();
                return;
            }
            context.Succeed(requirement);
        }
    }

    public class JWTAuthorizationRequirement : IAuthorizationRequirement
    {
    }
}
