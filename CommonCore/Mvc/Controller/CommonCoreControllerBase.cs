using CommonCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Newtonsoft.Json;
using CommonCore.Services.Interfaces;
using CommonCore.IOC;

namespace CommonCore.Mvc.Controller
{
    public abstract class CommonCoreControllerBase : ControllerBase
    {
        protected IServiceProvider ServiceProvider { get; set; } = KeyedDependencyResolver.Instance.Default;
            
        protected async Task<IActionResult> CallWithAuthAsync(Func<IActionResult> action)
        {
            var auth = Request.Headers["Authorization"];
            if (auth.None()) return Unauthorized();

            var service = ServiceProvider.GetService<IAuthorizationService>();

            bool authorized = service.Authorize(Request.Headers).Result;
            if (!authorized) return Unauthorized();
            return action();
        }

        protected IActionResult Json(object obj)
        {
            return Ok(JsonConvert.SerializeObject(obj));
        }
    }
}
